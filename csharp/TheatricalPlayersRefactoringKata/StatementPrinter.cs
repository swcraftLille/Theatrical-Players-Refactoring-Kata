using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata;

public static class StatementPrinter
{
    public static string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        var totalAmount = 0;
        var volumeCredits = 0;
        var result = string.Format("Statement for {0}\n", invoice.Customer);
        CultureInfo cultureInfo = new CultureInfo("en-US");

        foreach(var performance in invoice.Performances)
        {
            volumeCredits += VolumeCreditsFor(performance);

            // print line for this order
            result += string.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", PlayFor(performance).Name, Convert.ToDecimal(AmountFor(performance) / 100), performance.Audience);
            totalAmount += AmountFor(performance);
        }
        result += String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
        result += $"You earned {volumeCredits} credits\n";
        return result;

        int AmountFor(Performance aPerformance)
        {
            int resultAmount;
            switch (PlayFor(aPerformance).Type)
            {
                case "tragedy":
                    resultAmount = 40000;
                    if (aPerformance.Audience > 30)
                    {
                        resultAmount += 1000 * (aPerformance.Audience - 30);
                    }
                    break;
                case "comedy":
                    resultAmount = 30000;
                    if (aPerformance.Audience > 20)
                    {
                        resultAmount += 10000 + 500 * (aPerformance.Audience - 20);
                    }
                    resultAmount += 300 * aPerformance.Audience;
                    break;
                default:
                    throw new Exception("unknown type: " + PlayFor(aPerformance).Type);
            }

            return resultAmount;
        }

        Play PlayFor(Performance performance)
        {
            return plays[performance.PlayID];
        }

        int VolumeCreditsFor(Performance performance)
        {
            var volumeCredits = 0;
            volumeCredits += Math.Max(performance.Audience - 30, 0);
            if ("comedy" == PlayFor(performance).Type) volumeCredits += (int)Math.Floor((decimal)performance.Audience / 5);
            return volumeCredits;
        }
    }
}   

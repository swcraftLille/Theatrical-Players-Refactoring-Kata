using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata;

public static class StatementPrinter
{
    public static string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        var result = RenderPlainText(invoice, plays);
        return result;
    }

    private static int VolumeCreditsFor(Invoice invoice, Dictionary<string, Play> plays)
    {
        var volumeCredits = 0;
        foreach (var perf in invoice.Performances)
        {
            // add volume credits
            volumeCredits += Math.Max(perf.Audience - 30, 0);
            // add extra credit for every ten comedy attendees
            if ("comedy" == plays[perf.PlayID].Type) volumeCredits += (int)Math.Floor((decimal)perf.Audience / 5);
        }

        return volumeCredits;
    }

    private static string RenderPlainText(Invoice invoice, Dictionary<string, Play> plays)
    {
        var volumeCredits = VolumeCreditsFor(invoice, plays);
        decimal totalAmount = 0;
        var result = $"Statement for {invoice.Customer}\n";
        CultureInfo cultureInfo = new CultureInfo("en-US");
        foreach (var perf in invoice.Performances)
        {
            // print line for this order
            result += string.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", plays[perf.PlayID].Name, AmountFor(plays[perf.PlayID], perf), perf.Audience);
            totalAmount += AmountFor(plays[perf.PlayID], perf);
        }

        result += string.Format(cultureInfo, "Amount owed is {0:C}\n",totalAmount);
        result += $"You earned {volumeCredits} credits\n";
        return result;
    }

    private static decimal AmountFor(Play play, Performance perf)
    {
        var thisAmount = 0;
        switch (play.Type) 
        {
            case "tragedy":
                thisAmount = 400;
                if (perf.Audience > 30) {
                    thisAmount += 10 * (perf.Audience - 30);
                }
                break;
            case "comedy":
                thisAmount = 300;
                if (perf.Audience > 20) {
                    thisAmount += 100 + 5 * (perf.Audience - 20);
                }
                thisAmount += 3 * perf.Audience;
                break;
            default:
                throw new Exception("unknown type: " + play.Type);
        }

        return thisAmount;
    }

    public static string renderHtml(Invoice invoice, Dictionary<string, Play> plays)
    {
        throw new NotImplementedException();
    }
}   

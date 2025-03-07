﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata;

public static class StatementPrinter
{
    public static string Print(Invoice invoice, Dictionary<string, Play> plays)
    {
        var volumeCredits = VolumeCreditsFor(invoice, plays);

        var result = renderPlainText(invoice, plays, volumeCredits);
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

    private static string renderPlainText(Invoice invoice, Dictionary<string, Play> plays, int volumeCredits)
    {
        var totalAmount = 0;
        var result = string.Format("Statement for {0}\n", invoice.Customer);
        CultureInfo cultureInfo = new CultureInfo("en-US");
        foreach (var perf in invoice.Performances)
        {
            // print line for this order
            result += string.Format(cultureInfo, "  {0}: {1:C} ({2} seats)\n", plays[perf.PlayID].Name, Convert.ToDecimal(AmountFor(plays[perf.PlayID], perf) / 100), perf.Audience);
            totalAmount += AmountFor(plays[perf.PlayID], perf);
        }

        result += String.Format(cultureInfo, "Amount owed is {0:C}\n", Convert.ToDecimal(totalAmount / 100));
        result += $"You earned {volumeCredits} credits\n";
        return result;
    }

    private static int AmountFor(Play play, Performance perf)
    {
        var thisAmount = 0;
        switch (play.Type) 
        {
            case "tragedy":
                thisAmount = 40000;
                if (perf.Audience > 30) {
                    thisAmount += 1000 * (perf.Audience - 30);
                }
                break;
            case "comedy":
                thisAmount = 30000;
                if (perf.Audience > 20) {
                    thisAmount += 10000 + 500 * (perf.Audience - 20);
                }
                thisAmount += 300 * perf.Audience;
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

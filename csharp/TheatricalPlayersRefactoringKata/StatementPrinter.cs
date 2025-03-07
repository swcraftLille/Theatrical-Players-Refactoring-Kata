using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheatricalPlayersRefactoringKata;

public static class StatementPrinter
{
    public static string RenderPlainText(Invoice invoice, Dictionary<string, Play> plays)
    {
        var statementData = new StatementData()
        {
            TotalAmount = TotalAmountFor(invoice, plays),
            VolumeCredits = VolumeCreditsFor(invoice, plays),
            Customer = invoice.Customer,
            Performances = invoice.Performances,
        };

        var result = TextStatementFor(plays, statementData);
        return result;
    }

    private static string TextStatementFor(Dictionary<string, Play> plays,
        StatementData statementData)
    {
        var result = $"Statement for {statementData.Customer}\n";
        foreach (var perf in statementData.Performances)
        {
            result +=  $"  {plays[perf.PlayID].Name}: {ToUsDollar(AmountFor(plays[perf.PlayID], perf))} ({perf.Audience} seats)\n";
        }
        result += $"Amount owed is {ToUsDollar(statementData.TotalAmount)}\n";
        result += $"You earned {statementData.VolumeCredits} credits\n";
        return result;
    }

    private static decimal TotalAmountFor(Invoice invoice, Dictionary<string, Play> plays)
    {
        decimal totalAmount = 0;
        foreach (var perf in invoice.Performances)
        {
            totalAmount += AmountFor(plays[perf.PlayID], perf);
        }

        return totalAmount;
    }

    private static string ToUsDollar(decimal amountFor)
    {
        return string.Format(new CultureInfo("en-US"),"{0:C}", amountFor);
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

    public static string renderHtml(Invoice invoice, Dictionary<string, Play> plays)
    {
        throw new NotImplementedException();
    }
}
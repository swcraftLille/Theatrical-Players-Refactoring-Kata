using System;
using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace TheatricalPlayersRefactoringKata.Tests;

public class StatementPrinterTests
{
    [Fact]
    [UseReporter(typeof(DiffReporter))]
    public void Test_statement_example()
    {
        var plays = new Dictionary<string, Play>
        {
            { "hamlet", new Play("Hamlet", "tragedy") },
            { "as-like", new Play("As You Like It", "comedy") },
            { "othello", new Play("Othello", "tragedy") }
        };

        Invoice invoice = new("BigCo", [new Performance("hamlet", 55),
            new Performance("as-like", 35),
            new Performance("othello", 40)]);
        
        var result = StatementPrinter.RenderPlainText(invoice, plays);

        Approvals.Verify(result);
    }

    [Fact]
    public void Test_statement_with_new_play_types()
    {
        var plays = new Dictionary<string, Play>
        {
            { "henry-v", new Play("Henry V", "history") },
            { "as-like", new Play("As You Like It", "pastoral") }
        };

        Invoice invoice = new("BigCoII", [new Performance("henry-v", 53),
            new Performance("as-like", 55)]);
        
        Assert.Throws<Exception>(() => StatementPrinter.RenderPlainText(invoice, plays));
    }
}

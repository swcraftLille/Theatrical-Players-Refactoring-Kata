using System.Collections.Generic;

namespace TheatricalPlayersRefactoringKata;

public class StatementData
{
    public decimal TotalAmount { get; set; }
    public int VolumeCredits { get; set; }
    public string Customer { get; set; }
    public List<Performance> Performances { get; set; }
}
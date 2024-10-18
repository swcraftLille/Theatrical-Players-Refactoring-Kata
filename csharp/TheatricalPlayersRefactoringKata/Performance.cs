namespace TheatricalPlayersRefactoringKata;

public class Performance(string playID, int audience)
{
    public string PlayID { get; set; } = playID;
    public int Audience { get; set; } = audience;
}

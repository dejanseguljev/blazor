namespace SportsMonitor_Version6.Client.EventArgs;

public class VotesChangedArgs
{
    public Guid ParticipantId { get; set; }
    public int OldVotes { get; set; }
    public int NewVotes { get; set; }
}

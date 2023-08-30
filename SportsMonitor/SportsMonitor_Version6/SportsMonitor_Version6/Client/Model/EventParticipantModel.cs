using SportsMonitor_Version6.Client.Enums;

namespace SportsMonitor_Version6.Client.Model;

public class EventParticipantModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public float Score { get; set; }
    public EventParticipantStatus Status { get; set; }
    public int WinningVotes { get; set; }
}
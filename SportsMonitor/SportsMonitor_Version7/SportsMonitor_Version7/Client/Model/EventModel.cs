using SportsMonitor_Version7.Client.Enums;

namespace SportsMonitor_Version7.Client.Model;

public class EventModel
{
    public string? Name { get; set; }
    public EventStatus Status { get; set; }
    public DateTime? Date { get; set; }
    public List<EventParticipantModel>? Participants { get; set; }    
}
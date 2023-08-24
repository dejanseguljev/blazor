using SportsMonitor_Version5.Client.Enums;

namespace SportsMonitor_Version3.Client.Model;

public class EventModel
{
    public string? Name { get; set; }
    public EventStatus Status { get; set; }
    public DateTime? Date { get; set; }
    public List<EventParticipantModel>? Participants { get; set; }    
}
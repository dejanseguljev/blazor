using SportsMonitor.Client.Enums;

namespace SportsMonitor.Client.Model;

public class EventModel: ICloneable
{
    public string? Name { get; set; }
    public EventStatus Status { get; set; }
    public List<EventParticipantModel>? Participants { get; set; }
    public DateTime? Date { get; set; }

    public object Clone()
    {
        return new EventModel()
        {
            Name = Name,
            Status = Status,
            Date = Date,
            Participants = new List<EventParticipantModel>(
                Participants != null ?
                    Participants.Select(x => (EventParticipantModel)x.Clone()) : Array.Empty<EventParticipantModel>())
        };
    }
}

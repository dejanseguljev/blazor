using SportsMonitor.Client.Enums;

namespace SportsMonitor.Client.Model;

public class EventModel: ICloneable
{
    public string? Name { get; set; }
    public EventStatus Status { get; set; }
    public IList<EventParticipantModel> Participants { get; private set; } = new List<EventParticipantModel>();

    public object Clone()
    {
        return new EventModel()
        {
            Name = Name,
            Status = Status,
            Participants = new List<EventParticipantModel>(
                Participants.Select(x => (EventParticipantModel)x.Clone()))
        };
    }
}

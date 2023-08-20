using SportsMonitor.Client.Enums;
using SportsMonitor.Client.Records;
using System.Collections.ObjectModel;

namespace SportsMonitor.Client.Model;

public class EventModel : BaseModel<EventRecord>
{
    private string? _name;
    private EventStatus _status;
    private DateTime? _date;

    public string? Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }
    public EventStatus Status
    {
        get
        {
            return _status;
        }
        set
        {
            if (_status != value)
            {
                _status = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime? Date
    {
        get
        {
            return _date;
        }
        set
        {
            if (_date != value)
            {
                _date = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<EventParticipantModel>? Participants { get; set; }

    public override EventRecord GetRecord()
    {
        return new EventRecord()
        {
            Id = Id,
            Name = Name,
            Status = Status,
            Participants = new List<EventParticipantRecord>(this.Participants != null ?
                this.Participants.Select(x => x.GetRecord()) : Array.Empty<EventParticipantRecord>()),
        };
    }
}

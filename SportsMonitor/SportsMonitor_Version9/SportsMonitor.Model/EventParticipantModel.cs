namespace SportsMonitor.Model;

public record EventParticipantRecord(Guid Id = default, string? Name = null, float Score = default, int WinningVotes = default,
    EventParticipantStatus Status = default);
public class EventParticipantModel: BaseModel<EventParticipantRecord>
{
    private string? _name;
    private float _score;
    private int _winningVotes;
    private EventParticipantStatus _status;

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

    public float Score
    {
        get
        {
            return _score;
        }
        set
        {
            if (_score != value)
            {
                _score = value;
                OnPropertyChanged();
            }
        }
    }

    public int WinningVotes
    {
        get
        {
            return _winningVotes;
        }
        set
        {
            if (_winningVotes != value)
            {
                _winningVotes = value;
                OnPropertyChanged();
            }
        }
    }

    public EventParticipantStatus Status
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

    public override EventParticipantRecord GetRecord()
    {
        return new EventParticipantRecord()
        {
            Name = _name,
            Score = _score,
            WinningVotes = _winningVotes,
            Status = _status
        };
    }
}

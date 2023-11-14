using SportsMonitor.Client.Model;
using SportsMonitor.Client.Records;
using System.Collections.ObjectModel;

namespace SportsMonitor.Client.Services
{
    public class StateStorage : IStateStorage, IObserver<EventRecord>, IObserver<EventParticipantRecord>, IDisposable
    {
        private readonly Queue<EventRecord> _eventHistory = new Queue<EventRecord>();
        private List<EventModel> _events;
        private List<IDisposable> _subscriptions = new ();

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(EventRecord value)
        {
            // Send change to the API
        }

        public void OnNext(EventParticipantRecord value)
        {
            // Send change to the API
        }

        public IEnumerable<EventModel> GetEvents()
        {
            if (_events != null )
            {
                return _events;
            };

            _events = new List<EventModel>()
            {
                new EventModel()
                {
                    Name = "NBA Conference Finals",
                    Status = Enums.EventStatus.Complete,
                    Date = new DateTime(2023, 5, 23, 0, 40, 0, DateTimeKind.Utc),
                    Participants = new ObservableCollection<EventParticipantModel>( new List<EventParticipantModel>()
                    {
                        new EventParticipantModel()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Los Angeles Lakers",
                            Score = 111,
                            Status = EventParticipantStatus.Confirmed
                        },
                        new EventParticipantModel()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Denver Nuggets",
                            Score = 113,
                            Status = EventParticipantStatus.Confirmed
                        }
                    })
                },
                new EventModel()
                {
                    Name = "NBA Finals",
                    Status = Enums.EventStatus.Complete,
                    Date = new DateTime(2023, 6, 13, 0, 30, 0, DateTimeKind.Utc),
                    Participants = new ObservableCollection<EventParticipantModel>( new List<EventParticipantModel>()
                    {
                        new EventParticipantModel()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Denver Nuggets",
                            Score = 94,
                            Status = EventParticipantStatus.Confirmed
                        },
                        new EventParticipantModel()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Miami Heat",
                            Score = 89,
                            Status = EventParticipantStatus.Confirmed
                        }
                    })
                }
            };

            foreach (var item in _events)
            {
                _subscriptions.Add(item.Subscribe(this));

                if (item.Participants != null)
                {
                    foreach (var participant in item.Participants)
                    {
                        _subscriptions.Add(participant.Subscribe(this));
                    }
                }
            }

            return _events;
        }

        public void Dispose()
        {
            foreach (var subscription in _subscriptions)
            {
                subscription.Dispose();
            }

            _subscriptions.Clear();
            _subscriptions = null;
        }
    }
}

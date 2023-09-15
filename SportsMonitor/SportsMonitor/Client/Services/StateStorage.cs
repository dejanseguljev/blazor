using SportsMonitor.Client.Model;
using SportsMonitor.Client.Records;
using System.Collections.ObjectModel;

namespace SportsMonitor.Client.Services
{
    public class StateStorage : IStateStorage, IObserver<EventRecord>, IObserver<EventParticipantRecord>
    {
        private readonly Queue<EventRecord> _eventHistory = new Queue<EventRecord>();

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
            var events = new List<EventModel>()
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

            foreach (var item in events)
            {
                item.Subscribe(this);

                if (item.Participants != null)
                {
                    foreach (var participant in item.Participants)
                    {
                        participant.Subscribe(this);
                    }
                }
            }

            return events;
        }
    }
}

using SportsMonitor.Client.Enums;

namespace SportsMonitor.Client.Records
{
    public record EventRecord
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public EventStatus Status { get; set; }
        public DateTime? Date { get; set; }

        public List<EventParticipantRecord>? Participants { get; set; }
    }
}

namespace SportsMonitor.Client.Records
{
    public record EventParticipantRecord
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public float Score { get; set; }
        public int WinningVotes { get; set; }
        public EventParticipantStatus Status { get; set; }
    }
}

namespace SportsMonitor.Client.Model
{
    public class EventParticipantModel: ICloneable
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public float Score { get; set; }
        public EventParticipantStatus Status { get; set; }
        public int WinningVotes { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}

using SportsMonitor.Client.Model;

namespace SportsMonitor.Client.Services
{
    public interface IStateStorage
    {
        IEnumerable<EventModel> GetEvents();
    }
}

using SportsMonitor.Model;

namespace SportsMonitor.Model
{
    public interface IStateStorage
    {
        IEnumerable<EventModel> GetEvents();
    }
}

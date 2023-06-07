using Microsoft.AspNetCore.Components;
using SportsMonitor.Client.Model;

namespace SportsMonitor.Client.Core;

public class EventTrackerBase5 : ComponentBase
{
    private EventModel? _event;


    [Parameter]
    public EventModel? Event
    {
        get
        {
            return _event?.Clone() as EventModel;
        }
        set
        {
            _event = value != null ? value.Clone() as EventModel : null;
        }
    }

    [Parameter]
    public EventCallback<EventParticipantModel> OnTeamSelected { get; set; }
}

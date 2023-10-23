using Microsoft.AspNetCore.Components;
using SportsMonitor.Model;

namespace SportsMonitor.Core;

public class EventTrackerBase: ComponentBase
{
    [Parameter]
    public EventModel? Model { get; set; }

    [Parameter]
    public EventCallback<EventModel> ModelChanged { get; set; }
}

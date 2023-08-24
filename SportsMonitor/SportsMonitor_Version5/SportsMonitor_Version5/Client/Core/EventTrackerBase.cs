using Microsoft.AspNetCore.Components;
using SportsMonitor_Version3.Client.Model;

namespace SportsMonitor_Version5.Client.Core;

public class EventTrackerBase : ComponentBase
{
    [Parameter]
    public EventModel? Model { get; set; }

    [Parameter]
    public EventCallback<EventParticipantModel> OnTeamSelected { get; set; }
}
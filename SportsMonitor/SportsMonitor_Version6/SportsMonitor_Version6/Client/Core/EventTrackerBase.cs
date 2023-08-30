using Microsoft.AspNetCore.Components;
using SportsMonitor_Version6.Client.EventArgs;
using SportsMonitor_Version6.Client.Model;

namespace SportsMonitor_Version6.Client.Core;

public class EventTrackerBase : ComponentBase
{
    [Parameter]
    public EventModel? Model { get; set; }

    [Parameter]
    public EventCallback<EventParticipantModel> OnParticipantSelected { get; set; }

    [Parameter]
    public EventCallback<VotesChangedArgs> OnVotesChanged { get; set; }
}

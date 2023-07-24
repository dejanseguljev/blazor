using Microsoft.AspNetCore.Components;
using SportsMonitor.Client.EventArgs;
using SportsMonitor.Client.Model;

namespace SportsMonitor.Client.Core;

public class EventTrackerBase6 : ComponentBase
{
    [Parameter]
    public EventModel? Model { get; set; }

    [Parameter]
    public EventCallback<EventParticipantModel> OnParticipantSelected { get; set; }

    [Parameter]
    public EventCallback<VotesChangedArgs> OnVotesChanged { get; set; }
}

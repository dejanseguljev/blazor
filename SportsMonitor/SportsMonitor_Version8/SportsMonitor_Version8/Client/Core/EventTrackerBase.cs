﻿using Microsoft.AspNetCore.Components;
using SportsMonitor.Client.Model;

namespace SportsMonitor.Client.Core;

public class EventTrackerBase: ComponentBase
{
    [Parameter]
    public EventModel? Model { get; set; }

    [Parameter]
    public EventCallback<EventModel> ModelChanged { get; set; }

    [Parameter]
    public EventCallback<EventParticipantModel> OnParticipantSelected { get; set; }

    protected void IncreaseVotes(EventParticipantModel participant)
    {
        participant.WinningVotes++;
        ModelChanged.InvokeAsync();
    }

    protected void IncreaseScore(EventParticipantModel participant)
    {
        participant.Score++;
        ModelChanged.InvokeAsync();
    }
}

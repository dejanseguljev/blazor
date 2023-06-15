using Microsoft.AspNetCore.Components;
using SportsMonitor.Client.Model;

namespace SportsMonitor.Client.Core;

public class EventTrackerBase5 : ComponentBase
{
    //private EventModel? _model;


    //[Parameter]
    //public EventModel? Model
    //{
    //    get
    //    {
    //        return _model;
    //    }
    //    set
    //    {
    //        _model = value != null ? value.Clone() as EventModel : null;
    //    }
    //}

    [Parameter]
    public EventModel? Model { get; set; }

    [Parameter]
    public EventCallback<EventParticipantModel> OnTeamSelected { get; set; }
}

using Microsoft.AspNetCore.Components;
using SportsMonitor.Client.Model;
using SportsMonitor.Client.Records;
using SportsMonitor.Client.Services;

namespace SportsMonitor.Client.Core;

public class EventStatsBase: ComponentBase, IObserver<EventParticipantRecord>, IDisposable
{
    private IEnumerable<EventModel>? _events;
    private List<IDisposable> _subscriptions = new ();

    [Inject]
    public IStateStorage? Storage { get; set; }

    public int TotalVotes
    {
        get; set;
    }


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        _events = Storage.GetEvents();

        CalculateVotes();        

        foreach (var @event in _events)
        {
            foreach (var participant in @event.Participants)
            {
                participant.Subscribe(this);
            }
        }
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(EventParticipantRecord value)
    {
        CalculateVotes();
        StateHasChanged();
    }

    private void CalculateVotes()
    {
        TotalVotes = _events.Where(x => x.Participants?.Any() == true)
            .SelectMany(x => x.Participants).Sum(x => x.WinningVotes);
    }

    public void Dispose()
    {
        foreach (var subscription in _subscriptions)
        {
            subscription.Dispose();
        }

        _subscriptions.Clear();
        _subscriptions = null;
    }
}

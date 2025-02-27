namespace EvolutionaryArchitecture.Fitnet.Offers.Prepare;

using Data;
using Data.Database;
using Passes.MarkPassAsExpired.Events;
using Common.Events;
using Common.Events.EventBus;
using Common.SystemClock;

internal sealed class PassExpiredEventHandler : IIntegrationEventHandler<PassExpiredEvent>
{
    private readonly IEventBus _eventBus;
    private readonly OffersPersistence _persistence;
    private readonly ISystemClock _systemClock;

    public PassExpiredEventHandler(
        IEventBus eventBus,
        OffersPersistence persistence,
        ISystemClock systemClock)
    {
        _eventBus = eventBus;
        _persistence = persistence;
        _systemClock = systemClock;
    }

    public async Task Handle(PassExpiredEvent @event, CancellationToken cancellationToken)
    {
        var offer = Offer.PrepareStandardPassExtension(@event.CustomerId, _systemClock.Now);
        _persistence.Offers.Add(offer);
        await _persistence.SaveChangesAsync(cancellationToken);

        var offerPreparedEvent = OfferPrepareEvent.Create(offer.Id, offer.CustomerId);
        await _eventBus.PublishAsync(offerPreparedEvent, cancellationToken);
    }
}

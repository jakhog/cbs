using Dolittle.Events.Processing;
using Events.Admin.HealthRisks;
using MongoDB.Driver;

namespace Read.HealthRisks
{
    public class HealthRisksEventProcessor : ICanProcessEvents
    {
        readonly IMongoCollection<HealthRisk> _healthRisks;

        public HealthRisksEventProcessor(IMongoCollection<HealthRisk> healthRisks)
        {
            _healthRisks = healthRisks;
        }

        [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e13")]
        public void Process(HealthRiskCreated @event)
        {
            _healthRisks.Insert(new HealthRisk(@event.Id, @event.Name));
        }
    }
}

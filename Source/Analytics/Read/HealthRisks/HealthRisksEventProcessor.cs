using Dolittle.Events.Processing;
using Events.Admin.HealthRisks;

namespace Read.HealthRisks
{
    public class HealthRisksEventProcessor : ICanProcessEvents
    {
        [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e13")]
        public void Process(HealthRiskCreated @event)
        {
        }
    }
}

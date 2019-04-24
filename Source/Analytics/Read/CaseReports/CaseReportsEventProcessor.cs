using Dolittle.Events.Processing;
using Events.Reporting.Reporting.CaseReports;

namespace Read.CaseReports
{
    public class CaseReportsEventProcessor : ICanProcessEvents
    {
       [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(CaseReportReceived @event)
        {
        }
    }
}
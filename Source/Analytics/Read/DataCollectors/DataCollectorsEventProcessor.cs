using System;
using System.Collections.Generic;
using System.Text;
using Dolittle.Events.Processing;
using Events.Reporting.Management.DataCollectors.Registration;

namespace Read.DataCollectors
{
    public class DataCollectorsEventProcessor
    {   
        [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(DataCollectorRegistered @event)
        {
        }
    }
}

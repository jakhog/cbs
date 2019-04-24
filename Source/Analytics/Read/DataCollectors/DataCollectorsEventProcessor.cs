using System;
using System.Collections.Generic;
using System.Text;
using Dolittle.Events.Processing;
using Dolittle.Runtime.Events;
using Events.Reporting.Management.DataCollectors.Registration;
using MongoDB.Driver;

namespace Read.DataCollectors
{
    public class DataCollectorsEventProcessor
    {
        readonly IMongoCollection<DataCollector> _dataCollectors;

        public DataCollectorsEventProcessor(IMongoCollection<DataCollector> dataCollectors)
        {
            _dataCollectors = dataCollectors;
        }

        [EventProcessor("cb01aaaf-7998-4692-81ef-1ceb5ab38e12")]
        public void Process(DataCollectorRegistered @event, EventSourceId id)
        {
            _dataCollectors.Insert(new DataCollector(
                id,
                @event.FullName,
                @event.DisplayName,
                @event.YearOfBirth,
                @event.Sex,
                @event.PreferredLanguage,
                @event.LocationLongitude,
                @event.LocationLatitude,
                @event.RegisteredAt,
                @event.Region,
                @event.District
            ));
        }
    }
}

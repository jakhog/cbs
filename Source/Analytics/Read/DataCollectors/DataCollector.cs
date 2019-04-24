using System;
using Dolittle.ReadModels;

namespace Read.DataCollectors
{
    public class DataCollector : IReadModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string DisplayName { get; set; }
        public int YearOfBirth { get; set; }
        public int Sex { get; set; }
        public int PreferredLanguage { get; set; }
        public double LocationLongitude { get; set; }
        public double LocationLatitude { get; set; }
        public string Region { get; set; }
        public string District { get; set; }
        public DateTimeOffset RegisteredAt { get; set; }

        public DataCollector(Guid id)
        {
            Id = id;
        }

        public DataCollector(
            Guid id,
            string fullName,
            string displayName,
            int yearOfBirth,
            int sex,
            int preferredLanguage,
            double locationLongitude,
            double locationLatitude,
            DateTimeOffset registeredAt,
            string region,
            string district)
        {
            Id = id;
            FullName = fullName;
            DisplayName = displayName;
            YearOfBirth = yearOfBirth;
            Sex = sex;
            PreferredLanguage = preferredLanguage;
            LocationLongitude = locationLongitude;
            LocationLatitude = locationLatitude;
            RegisteredAt = registeredAt;
            Region = region;
            District = district;
        }
    }
}

using Dolittle.Concepts;

namespace Concepts.HealthRisks
{
    public class HealthRiskName : ConceptAs<string>
    {
        public static implicit operator HealthRiskName(string value)
        {
            return new HealthRiskName {Value = value};
        }
    }
}
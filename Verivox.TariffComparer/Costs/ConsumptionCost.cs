using Verivox.TariffComparer.Domain;
using Verivox.TariffComparer.Domain.Consumption;

namespace Verivox.TariffComparer.Costs
{
    public class ConsumptionCost : Cost
    {
        protected IConsumption _consumption;

        public ConsumptionCost(IConsumption consumption)
        {
            _consumption = consumption;
        }

        public override double GetTotalCost()
        {
            return _consumption.GetKilowatsHourPerYear() * _baseCost;
        }
    }
}

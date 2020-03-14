using Verivox.TariffComparer.Domain;
using Verivox.TariffComparer.Domain.Consumption;

namespace Verivox.TariffComparer.Costs
{
    public class ConsumptionRangeCost : Cost
    {
        protected IConsumption _consumption;
        protected double _consumptionLimit;
        protected double _costAfterLimit;

        public ConsumptionRangeCost(IConsumption consumption)
        {
            _consumption = consumption;
        }

        public override double GetTotalCost()
        {
            double kwhPerYear = _consumption.GetKilowatsHourPerYear();

            if (kwhPerYear > _consumptionLimit)
            {
                double additionalCost = (kwhPerYear - _consumptionLimit) * _costAfterLimit;

                return _baseCost + additionalCost;
            }

            return _baseCost;

        }

        public void SetCostAfterLimit(double cost)
        {
            _costAfterLimit = cost;
        }

        public void SetCostBeforeLimit(double cost)
        {
            base.SetCost(cost);
        }

        public void SetConsumptionLimit(double consumptionLimit)
        {
            _consumptionLimit = consumptionLimit;
        }
    }
}

using Verivox.TariffComparer.Domain;

namespace Verivox.TariffComparer.Costs
{
    public class YearlyCost : Cost
    {
        public override void SetCost(double monthlyCost)
        {
            base.SetCost(monthlyCost);
        }

        public override double GetTotalCost()
        {
            return _baseCost * 12;
        }
    }
}

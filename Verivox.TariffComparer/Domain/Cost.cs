namespace Verivox.TariffComparer.Domain
{
    public abstract class Cost
    {
        protected double _baseCost;
        public virtual void SetCost(double baseCost)
        {
            _baseCost = baseCost;
        }

        public abstract double GetTotalCost();
    }
}

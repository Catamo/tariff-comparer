using System.Collections.Generic;

namespace Verivox.TariffComparer.Domain
{
    public abstract class Product
    {
        protected double _annualCosts;

        public string TariffName { get; set; }
        public double AnnualCosts => _annualCosts;
    }
}

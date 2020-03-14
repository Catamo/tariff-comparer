using System;
using System.Collections.Generic;
using System.Text;
using Verivox.TariffComparer.Costs;
using Verivox.TariffComparer.Domain;
using Verivox.TariffComparer.Infrastructure;

namespace Verivox.TariffComparer.Products
{
    public class PackagedTariff : Product
    {
        public PackagedTariff()
        {
            this.TariffName = "Packaged Tariff";

            ConsumptionRangeCost consumptionRangeCost = Injector.Get<ConsumptionRangeCost>();
            consumptionRangeCost.SetCostBeforeLimit(800);//Euros
            consumptionRangeCost.SetConsumptionLimit(4000);//kWh
            consumptionRangeCost.SetCostAfterLimit(0.30);//Euro cents

            _annualCosts = consumptionRangeCost.GetTotalCost();
        }
    }
}

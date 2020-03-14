using Verivox.TariffComparer.Costs;
using Verivox.TariffComparer.Domain;
using Verivox.TariffComparer.Infrastructure;

namespace Verivox.TariffComparer.Products
{
    public class BasicElectricityTariff : Product
    {
        public BasicElectricityTariff()
        {
            TariffName = "Basic Electricity Tariff";

            Cost yearlyCost = Injector.Get<YearlyCost>();
            yearlyCost.SetCost(5);//Euros

            Cost consumptionCost = Injector.Get<ConsumptionCost>();
            consumptionCost.SetCost(0.22);//Euro cents

            _annualCosts = yearlyCost.GetTotalCost() + consumptionCost.GetTotalCost();
        }
    }
}

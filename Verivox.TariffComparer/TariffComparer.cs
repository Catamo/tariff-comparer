using System.Collections.Generic;
using System.Linq;
using Verivox.TariffComparer.Domain;
using Verivox.TariffComparer.Domain.Consumption;
using Verivox.TariffComparer.Infrastructure;
using Verivox.TariffComparer.Products;

namespace Verivox.TariffComparer
{
    public class TariffComparer
    {
        public virtual IEnumerable<Product> RegisteredProductsList()
        {
            List<Product> products = new List<Product>();

            products.Add(new BasicElectricityTariff());
            products.Add(new PackagedTariff());

            return products.OrderBy(x => x.AnnualCosts);
        }

        public IEnumerable<Product> Compare(double yearlyConsumption)
        {
            Startup.Init();
            Injector.Map<IConsumption>(() => new Consumption(yearlyConsumption));

            return RegisteredProductsList();
        }
    }
}

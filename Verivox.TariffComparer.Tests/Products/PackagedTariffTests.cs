using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Verivox.TariffComparer.Domain.Consumption;
using Verivox.TariffComparer.Infrastructure;
using Verivox.TariffComparer.Products;

namespace Tests.Products
{
    public class PackagedTariffTests
    {
        [SetUp]
        public void Setup()
        {
            Verivox.TariffComparer.Infrastructure.Startup.Init();
        }

        [Test]
        public void PackagedTariff_AnnualCosts_3500kWh()
        {
            Injector.Map<IConsumption>(() => new Consumption(3500));

            PackagedTariff tariff = new PackagedTariff();

            double totalCost = tariff.AnnualCosts;

            Assert.AreEqual(800, totalCost);
        }

        [Test]
        public void PackagedTariff_AnnualCosts_4500kWh()
        {
            Injector.Map<IConsumption>(() => new Consumption(4500));

            PackagedTariff tariff = new PackagedTariff();

            double totalCost = tariff.AnnualCosts;

            Assert.AreEqual(950, totalCost);
        }

        [Test]
        public void PackagedTariff_AnnualCosts_6000kWh()
        {
            Injector.Map<IConsumption>(() => new Consumption(6000));

            PackagedTariff tariff = new PackagedTariff();

            double totalCost = tariff.AnnualCosts;

            Assert.AreEqual(1400, totalCost);
        }

        [TearDown]
        public void TearDown()
        {
            Injector.Clear();
        }
    }
}

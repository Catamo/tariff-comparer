using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Verivox.TariffComparer.Domain.Consumption;
using Verivox.TariffComparer.Infrastructure;
using Verivox.TariffComparer.Products;

namespace Tests.Products
{
    public class BasicElectricityTariffTests
    {
        [SetUp]
        public void Setup()
        {
            Verivox.TariffComparer.Infrastructure.Startup.Init();
        }

        [Test]
        public void BasicElectricityTariff_AnnualCosts_3500kWh()
        {
            Injector.Map<IConsumption>(() => new Consumption(3500));

            BasicElectricityTariff tariff = new BasicElectricityTariff();

            double totalCost = tariff.AnnualCosts;

            Assert.AreEqual(830, totalCost);
        }

        [Test]
        public void BasicElectricityTariff_AnnualCosts_4500kWh()
        {
            Injector.Map<IConsumption>(() => new Consumption(4500));

            BasicElectricityTariff tariff = new BasicElectricityTariff();

            double totalCost = tariff.AnnualCosts;

            Assert.AreEqual(1050, totalCost);
        }

        [Test]
        public void BasicElectricityTariff_AnnualCosts_6000kWh()
        {
            Injector.Map<IConsumption>(() => new Consumption(6000));

            BasicElectricityTariff tariff = new BasicElectricityTariff();

            double totalCost = tariff.AnnualCosts;

            Assert.AreEqual(1380, totalCost);
        }

        [TearDown]
        public void TearDown()
        {
            Injector.Clear();
        }
    }
}

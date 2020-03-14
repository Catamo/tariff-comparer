using Moq;
using NUnit.Framework;
using Verivox.TariffComparer.Costs;
using Verivox.TariffComparer.Domain.Consumption;
using Verivox.TariffComparer.Infrastructure;

namespace Tests.Costs
{
    public class YearlyCostTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Verivox.TariffComparer.Infrastructure.Startup.Init();
        }

        [Test]
        public void YearlyCost_GetTotalCost_5Euros()
        {
            YearlyCost consumptionCost = new YearlyCost();
            consumptionCost.SetCost(5);

            double totalCost = consumptionCost.GetTotalCost();

            Assert.AreEqual(60, totalCost);
        }

        [Test]
        public void YearlyCost_GetTotalCost_10Euros()
        {
            YearlyCost consumptionCost = new YearlyCost();
            consumptionCost.SetCost(10);

            double totalCost = consumptionCost.GetTotalCost();

            Assert.AreEqual(120, totalCost);
        }

        [TearDown]
        public void TearDown()
        {
            Injector.Clear();
        }
    }
}

using Moq;
using NUnit.Framework;
using Verivox.TariffComparer.Costs;
using Verivox.TariffComparer.Domain.Consumption;
using Verivox.TariffComparer.Infrastructure;

namespace Tests.Costs
{
    public class ConsumptionCostTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Verivox.TariffComparer.Infrastructure.Startup.Init();
        }

        [Test]
        public void ConsumptionCost_GetTotalCost_3500kWh()
        {
            Mock<IConsumption> mockConsumption = new Mock<IConsumption>();
            mockConsumption.Setup(x => x.GetKilowatsHourPerYear()).Returns(3500);

            ConsumptionCost consumptionCost = new ConsumptionCost(mockConsumption.Object);
            consumptionCost.SetCost(0.22);

            double totalCost = consumptionCost.GetTotalCost();

            Assert.AreEqual(770, totalCost);
        }

        [Test]
        public void ConsumptionCost_GetTotalCost_4500kWh()
        {
            Mock<IConsumption> mockConsumption = new Mock<IConsumption>();
            mockConsumption.Setup(x => x.GetKilowatsHourPerYear()).Returns(4500);

            ConsumptionCost consumptionCost = new ConsumptionCost(mockConsumption.Object);
            consumptionCost.SetCost(0.22);

            double totalCost = consumptionCost.GetTotalCost();

            Assert.AreEqual(990, totalCost);
        }

        [Test]
        public void ConsumptionCost_GetTotalCost_6000kWh()
        {
            Mock<IConsumption> mockConsumption = new Mock<IConsumption>();
            mockConsumption.Setup(x => x.GetKilowatsHourPerYear()).Returns(6000);

            ConsumptionCost consumptionCost = new ConsumptionCost(mockConsumption.Object);
            consumptionCost.SetCost(0.22);

            double totalCost = consumptionCost.GetTotalCost();

            Assert.AreEqual(1320, totalCost);
        }

        [TearDown]
        public void TearDown()
        {
            Injector.Clear();
        }
    }
}

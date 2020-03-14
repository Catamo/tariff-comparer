using Moq;
using NUnit.Framework;
using Verivox.TariffComparer.Costs;
using Verivox.TariffComparer.Domain.Consumption;
using Verivox.TariffComparer.Infrastructure;

namespace Tests.Costs
{
    public class ConsumptionRangeCostTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Verivox.TariffComparer.Infrastructure.Startup.Init();
        }

        [Test]
        public void ConsumptionRangeCost_GetTotalCost_3500kWh()
        {
            Mock<IConsumption> mockConsumption = new Mock<IConsumption>();
            mockConsumption.Setup(x => x.GetKilowatsHourPerYear()).Returns(3500);

            ConsumptionRangeCost consumptionRangeCost = new ConsumptionRangeCost(mockConsumption.Object);
            consumptionRangeCost.SetCostBeforeLimit(800);
            consumptionRangeCost.SetConsumptionLimit(4000);
            consumptionRangeCost.SetCostAfterLimit(0.30);

            double totalCost = consumptionRangeCost.GetTotalCost();

            Assert.AreEqual(800, totalCost);
        }

        [Test]
        public void ConsumptionRangeCost_GetTotalCost_4500kWh()
        {
            Mock<IConsumption> mockConsumption = new Mock<IConsumption>();
            mockConsumption.Setup(x => x.GetKilowatsHourPerYear()).Returns(4500);

            ConsumptionRangeCost consumptionRangeCost = new ConsumptionRangeCost(mockConsumption.Object);
            consumptionRangeCost.SetCostBeforeLimit(800);
            consumptionRangeCost.SetConsumptionLimit(4000);
            consumptionRangeCost.SetCostAfterLimit(0.30);

            double totalCost = consumptionRangeCost.GetTotalCost();

            Assert.AreEqual(950, totalCost);
        }

        [Test]
        public void ConsumptionRangeCost_GetTotalCost_6000kWh()
        {
            Mock<IConsumption> mockConsumption = new Mock<IConsumption>();
            mockConsumption.Setup(x => x.GetKilowatsHourPerYear()).Returns(6000);

            ConsumptionRangeCost consumptionRangeCost = new ConsumptionRangeCost(mockConsumption.Object);
            consumptionRangeCost.SetCostBeforeLimit(800);
            consumptionRangeCost.SetConsumptionLimit(4000);
            consumptionRangeCost.SetCostAfterLimit(0.30);

            double totalCost = consumptionRangeCost.GetTotalCost();

            Assert.AreEqual(1400, totalCost);
        }

        [TearDown]
        public void TearDown()
        {
            Injector.Clear();
        }
    }
}

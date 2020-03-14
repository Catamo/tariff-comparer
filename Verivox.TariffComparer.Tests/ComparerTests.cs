using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Verivox.TariffComparer;
using Verivox.TariffComparer.Domain;
using Verivox.TariffComparer.Infrastructure;
using Verivox.TariffComparer.Products;

namespace Tests
{
    public class Tests
    {
        public IEnumerable<Product> TestProductsList()
        {
            List<Product> products = new List<Product>();

            products.Add(new BasicElectricityTariff());
            products.Add(new PackagedTariff());

            return products.OrderBy(x => x.AnnualCosts);
        }

        [Test]
        public void TariffComparer_Compare_3500kWh()
        {
            Mock<TariffComparer> comparer = new Mock<TariffComparer>();
            comparer.CallBase = true;

            comparer.Setup(x => x.RegisteredProductsList()).Returns(TestProductsList);

            var products = comparer.Object.Compare(3500).ToList();

            Assert.AreEqual(products[0].TariffName, "Packaged Tariff");
            Assert.AreEqual(products[1].TariffName, "Basic Electricity Tariff");

            Assert.AreEqual(products[0].AnnualCosts, 800);
            Assert.AreEqual(products[1].AnnualCosts, 830);
        }

        [Test]
        public void TariffComparer_Compare_4500kWh()
        {
            Mock<TariffComparer> comparer = new Mock<TariffComparer>();
            comparer.CallBase = true;

            comparer.Setup(x => x.RegisteredProductsList()).Returns(TestProductsList);

            var products = comparer.Object.Compare(4500).ToList();

            Assert.AreEqual(products[0].TariffName, "Packaged Tariff");
            Assert.AreEqual(products[1].TariffName, "Basic Electricity Tariff");

            Assert.AreEqual(products[0].AnnualCosts, 950);
            Assert.AreEqual(products[1].AnnualCosts, 1050);
        }

        [Test]
        public void TariffComparer_Compare_6000kWh()
        {
            Mock<TariffComparer> comparer = new Mock<TariffComparer>();
            comparer.CallBase = true;

            comparer.Setup(x => x.RegisteredProductsList()).Returns(TestProductsList);

            var products = comparer.Object.Compare(6000).ToList();

            Assert.AreEqual(products[0].TariffName, "Basic Electricity Tariff");
            Assert.AreEqual(products[1].TariffName, "Packaged Tariff");

            Assert.AreEqual(products[0].AnnualCosts, 1380);
            Assert.AreEqual(products[1].AnnualCosts, 1400);
        }

        [TearDown]
        public void TearDown()
        {
            Injector.Clear();
        }
    }
}
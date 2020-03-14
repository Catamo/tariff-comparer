
# Tariff Comparison

This project compares Products based on their annual costs.

It is made using C#, .NET Standard and .NET Core with NUnit + Moq for the tests. 

The Tariff comparer is composed of Costs and Products. Costs are the building blocks used to create the Products and to calculate the annual cost used to compare them. There are two example products:

- Basic Electricity Tariff:

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

- Packaged Tariff:

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

## Design Decisions

The library was made having in mind design patterns like the Decorator Pattern, the Strategy Pattern, and the Builder Pattern. While I did not apply them by the book, I think I used their concepts to create an extendable and maintainable code.

I thought of using the Decorator Pattern, as it provides a way to add new behaviors at runtime and it fitted what I had in mind of having building blocks to create the products. But in the end, applied another way of making this building blocks approach. 

But the pattern that I applied the most was the Builder Pattern. I used it along the custom Dependency Injection I implemented to resolve all the dependencies to get the instances, in this case, the dependency needed was the Consumption for the Costs which needed it. Once having the instance, I used the Builder Pattern to set up the information needed for the calculations.
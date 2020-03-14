using Verivox.TariffComparer.Costs;

namespace Verivox.TariffComparer.Infrastructure
{
    public class Startup
    {
        public static void Init()
        {
            RegisterCosts();
        }

        protected static void RegisterCosts()
        {
            Injector.Map<ConsumptionCost>();
            Injector.Map<ConsumptionRangeCost>();
            Injector.Map<YearlyCost>();
        }
    }
}

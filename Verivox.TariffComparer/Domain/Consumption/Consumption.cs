namespace Verivox.TariffComparer.Domain.Consumption
{
    public class Consumption : IConsumption
    {
        protected double _kilowatsHourPerYear;

        public Consumption(double kilowatsHourPerYear)
        {
            _kilowatsHourPerYear = kilowatsHourPerYear;
        }

        public double GetKilowatsHourPerYear() => _kilowatsHourPerYear;
    }
}

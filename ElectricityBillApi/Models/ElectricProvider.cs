using System;

namespace ElectricityBillApi.Models
{
    public class ElectricProvider
    {
        private PowerPlant _subscibedPowerPlant;

        public string Name { get; set; }

        public decimal CalculatePrice(Address address)
        {
            if (_subscibedPowerPlant == default) throw new ArgumentNullException(nameof(address));

            double priceDistanceFactor = CalculateDistanceFactor(address);
            return _subscibedPowerPlant.ElectricityPrice * (decimal)priceDistanceFactor;
        }

        public void Subscribe(PowerPlant powerPlant)
        {
            if (_subscibedPowerPlant is null)
            {
                _subscibedPowerPlant = powerPlant;
                return;
            }

            throw new InvalidOperationException($"Povider {_subscibedPowerPlant.Name} already subscribed to a power plant.");
        }

        public void Unsubscribe(PowerPlant powerPlant)
        {
            if (powerPlant == _subscibedPowerPlant)
            {
                _subscibedPowerPlant = default;
            }
        }

        private double CalculateDistanceFactor(Address address)
        {
            var xFac = Math.Abs(_subscibedPowerPlant.Location.X - address.Location.X);
            var yFac = Math.Abs(_subscibedPowerPlant.Location.Y - address.Location.Y);
            var zFac = Math.Abs(_subscibedPowerPlant.Location.Z - address.Location.Z);

            return xFac + yFac + zFac;
        }
    }
}
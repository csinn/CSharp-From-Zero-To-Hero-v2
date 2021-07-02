using ElectricBillApi.Models;

namespace ElectricBillApi.Interfaces
{
    public interface IElectricityProvider
    {
        void Subscribe(PowerPlant plant);
        void Unsubscribe(PowerPlant plant);
        decimal CalculatePrice(Address address);
    }
}

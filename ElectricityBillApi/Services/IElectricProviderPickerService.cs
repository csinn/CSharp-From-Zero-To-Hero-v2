using ElectricityBillApi.Models;

namespace ElectricityBillApi.Services
{
    public interface IElectricProviderPickerService
    {
        (ElectricProvider, decimal) FindCheapestProviderAndPrice(Address address);
    }
}
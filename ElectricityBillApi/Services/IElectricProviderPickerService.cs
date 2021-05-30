using ElectricityBillApi.Models;

namespace ElectricityBillApi.Services
{
    public interface IElectricProviderPickerService
    {
        ElectricProvider FindCheapest(Address address);
    }
}
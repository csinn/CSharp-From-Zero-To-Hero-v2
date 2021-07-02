using ElectricBillApi.Models;
using ElectricBillApi.Services;

namespace ElectricBillApi.Interfaces
{
    public interface IElectricProviderPicker
    {
        ElectricityProvider FindCheapest(Address adress);
    }
}

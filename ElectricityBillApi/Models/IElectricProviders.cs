using System.Collections.Generic;

namespace ElectricityBillApi.Models
{
    public interface IElectricProviders
    {
        List<ElectricProvider> GetProviders { get; }
    }
}
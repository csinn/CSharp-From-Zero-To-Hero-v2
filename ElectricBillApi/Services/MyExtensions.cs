using ElectricBillApi.Exceptions;

namespace ElectricBillApi.Services
{
    public static class MyExtensions
    {
        public static ElectricityProvider StringToProvider(this string name)
{
            foreach (var provider in ElectricProviderPicker.ElectricityProviders)
            {
                if(name == provider.Name)
                {
                    return provider;
                }
            }

            throw new NoProviderFoundException("No such electricityprovider exists.");
        }
    }

}

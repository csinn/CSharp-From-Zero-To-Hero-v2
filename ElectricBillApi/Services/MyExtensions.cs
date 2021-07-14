using ElectricBillApi.Exceptions;
using ElectricBillApi.Interfaces;
using ElectricBillApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

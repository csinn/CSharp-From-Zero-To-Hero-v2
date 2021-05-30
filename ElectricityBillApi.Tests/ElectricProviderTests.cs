using ElectricityBillApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectricityBillApi.Tests
{
    public class ElectricProviderTests
    {
        private ElectricProvider _sut;

        public ElectricProviderTests()
        {
            _sut = new ElectricProvider()
            {
                Name = "Test Provider"
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectricBillApi.Models
{
    public class Location : IComparable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

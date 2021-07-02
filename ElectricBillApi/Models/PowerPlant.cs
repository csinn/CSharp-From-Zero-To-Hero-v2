﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ElectricBillApi.Models
{
    public class PowerPlant
    {
        public Location Location { get; set; }
        public decimal ElectricityPrice { get; set; }
        public double ProducedPowerPerDay { get; set; }
        public string Name { get; set; }
    }
}

namespace ElectricityBillApi.Models
{
    public class PowerPlant
    {
        public decimal ElectricityPrice { get; set; }
        public Location Location { get; set; }
        public string Name { get; set; }
        public double ProducedPowerPerDay { get; set; }
    }
}
namespace ElectricityBillApi.Models
{
    public class Address
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string HouseNumber { get; set; }
        public Location Location { get; set; }
        public string Street { get; set; }
    }
}
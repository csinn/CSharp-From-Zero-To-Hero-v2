namespace ElectricBillApi.Models
{
    public class PowerPlant
    {
        public Location Location { get; set; }
        public decimal ElectricityPrice { get; set; }
        public double ProducedPowerPerDay { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if(!(obj is PowerPlant))
            {
                return false;
            }

            var other = obj as PowerPlant;

            if (this.Name.ToLower() == other.Name.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(PowerPlant a, PowerPlant b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(PowerPlant a, PowerPlant b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}

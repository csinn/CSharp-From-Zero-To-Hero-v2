namespace ElectricBillApi.Models
{
    public class Range
    {
        public decimal End { get; }
        public decimal Cost { get; }

        public Range(decimal end, decimal cost)
        {
            End = end;
            Cost = cost;
        }
    }
}

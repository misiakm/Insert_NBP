namespace InsertNbp.Web.Models
{
    public class CurrencyRateModel
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public double Mid { get; set; }
        public double? Ask { get; set; }
        public double? Bid { get; set; }
    }
}

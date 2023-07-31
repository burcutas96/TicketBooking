namespace Entities.DTOs
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string FlightNo { get; set; }
        public string FlightType { get; set; }
        public string AirlineCode { get; set; }
        public string? Airline { get; set; }
        public string DepTime { get; set; }
        public string ArrTime { get; set; }
        public string DepPort { get; set; }
        public string ArrPort { get; set; }
        public string FlightDate { get; set; }
        public List<PassengerPrice> PassengerPrices { get; set; }

    }

    public class PassengerPrice
    {
        public string Type { get; set; }
        public float BasePrice { get; set; }
        public float TotalTax { get; set; }
        public float Surcharge { get; set; }
        public float SalesPrice { get; set; }
        public string Currency { get; set; }
    }
}

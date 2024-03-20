namespace FlightOrdersManagementStudio
{
    public class OrderFlightSchduleEntry
    {
        public string OrderNumber { get; set; }
        public int FlightNumber { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public int Day { get; set; }
        public int FlightMaxCapacity { get; set; } = 20;
        public int FlightOrdersLoadedCount { get; set; } = 0;
    }
}

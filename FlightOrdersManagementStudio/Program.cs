using System;
using System.Collections.Generic;
using System.IO;

namespace FlightOrdersManagementStudio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Load Orders
            string json = File.ReadAllText(@"../../Orders.json");

            //Userstory 1:

            // We can only have 3 flights per day as company only have
            // 3 planes and only one flight per day.
           
            List<string> FlightsDestinationPerDay = new List<string>() { "YYC", "YVR", "YYZ" };
            List<FlightScheduleEntry> FlightsSchedule = new List<FlightScheduleEntry>();
            FlightsSchedule.AddRange(FlightManager.getFlightSchdule(FlightsDestinationPerDay, 5));

            Console.WriteLine("Userstory 1: ");
            Console.WriteLine("Here is the schdule of flight for 5 days based on number of destinations.");
            foreach (FlightScheduleEntry entry in FlightsSchedule)
            {
                Console.WriteLine($"Flight: {entry.FlightNumber}, departure: {entry.Origin}, arrival: {entry.Destination}, day: {entry.Day}");
            }

            //Userstory 2:

            List<OrderFlightSchduleEntry> orderFlightSchduleEntries = new List<OrderFlightSchduleEntry>();
            orderFlightSchduleEntries.AddRange(FlightManager.getLoadedFlightSchedule(json));
            Console.WriteLine("Userstory 2: ");
            Console.WriteLine("Here is the schedule of flight based on order deliveries:");
            foreach (var ofse in orderFlightSchduleEntries)
            {
                Console.WriteLine($"Order: {ofse.OrderNumber}, flightNumber: {ofse.FlightNumber}, departure: {ofse.Origin}, arrival: {ofse.Destination}, day: {ofse.Day}");
            }
            Console.Read();
        }
    }
}

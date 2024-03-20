using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightOrdersManagementStudio
{
    public class FlightManager
    {
        /// <summary>
        /// This method fetches the loaded flight schedule based on the Orders json file
        /// </summary>
        /// <param name="FlightsAvailablePerDay"></param>
        /// <param name="json"></param>
        /// <returns>Returns the schduled flights based on the Orders</returns>
        public static List<OrderFlightSchduleEntry> getLoadedFlightSchedule(string json)
        {
            Dictionary<string, Order> orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json);
            try
            {
                List<OrderFlightSchduleEntry> orderFlightSchduleEntries = new List<OrderFlightSchduleEntry>();
                List<string> lstDest = new List<string>();
                lstDest.AddRange(orders.Values.Select(order => order.Destination).Distinct());
                
                for (int i = 0; i < lstDest.Count; i++)
                {
                    int FlightNumber = 1 + i; int OrderLoaded = 0; int Day = 1;
                    foreach (KeyValuePair<string, Order> r in orders)
                    {
                        if (lstDest[i] == r.Value.Destination)
                        {
                            OrderLoaded++;
                            if(OrderLoaded > 20)
                            {
                                FlightNumber += lstDest.Count;
                                OrderLoaded = 0;
                                Day++;
                            }
                            OrderFlightSchduleEntry orderFlightSchduleEntry = new OrderFlightSchduleEntry() 
                            { FlightNumber = FlightNumber, OrderNumber = r.Key, FlightOrdersLoadedCount = OrderLoaded, Day = Day,  Destination = r.Value.Destination, Origin = "YUL" };
                            orderFlightSchduleEntries.Add(orderFlightSchduleEntry);
                        }
                    }
                }

                return orderFlightSchduleEntries.OrderBy(f=>f.OrderNumber).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// This Method returns the Flight schdule for Number of days provided for which user wants to see the schedule. 
        /// As mentioned in the user story based on the Scenario mentioned company has only 3 planes and 3 destinations can be covered per day. 
        /// </summary>
        /// <param name="FlightsDestinationPerDay"></param>
        /// <param name="NumberOfDays">This parameter denotes the number of days for which user wants to print the schedule with given number of destination. </param>
        /// <returns></returns>
        public static List<FlightScheduleEntry> getFlightSchdule(List<string> FlightsDestinationPerDay, int NumberOfDays)
        {
            List<FlightScheduleEntry> FlightsSchedule = new List<FlightScheduleEntry>();
            try
            {
                for (int i = 0; i < FlightsDestinationPerDay.Count; i++)
                {
                    int FlightNumber = 1 + i;
                    for (int j = 0; j < NumberOfDays; j++)
                    {
                        FlightScheduleEntry entry = new FlightScheduleEntry()
                        { FlightNumber = FlightNumber, Day = j + 1, Origin = "YUL", Destination = FlightsDestinationPerDay[i] };

                        FlightsSchedule.Add(entry);
                        FlightNumber = FlightNumber + FlightsDestinationPerDay.Count;
                    }
                }
                return FlightsSchedule.OrderBy(d => d.Day).OrderBy(f => f.FlightNumber).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                FlightsSchedule = null;
            }
        }
    }
}

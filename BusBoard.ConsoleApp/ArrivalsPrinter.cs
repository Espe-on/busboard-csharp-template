using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class ArrivalsPrinter 
    {
        public static void Print(IEnumerable<ArrivalDetails> arrivalsList)
        {
            Console.WriteLine($"The station is {arrivalsList.First().StationName}");
            foreach (var bus in arrivalsList)
            {
                Console.WriteLine($"The {bus.LineName} " +
                                  $"towards {bus.DestinationName} " +
                                  $"will arrive in {bus.TimeToStation} seconds.");
            }
        }
    }
}
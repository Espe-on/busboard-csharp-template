using System;
using System.Collections.Generic;

namespace BusBoard
{
    public class ArrivalsPrinter 
    {
        public static void Print(List<ArrivalDetails>arrivalsList)
        {
            Console.WriteLine($"The station is {arrivalsList[0].StationName}");
            foreach (var bus in arrivalsList)
            {
                Console.WriteLine($"The {bus.LineName} " +
                                  $"towards {bus.DestinationName} " +
                                  $"will arrive in {bus.TimeToStation} seconds.");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class ArrivalsPrinter 
    {
        public static void Print(IEnumerable<ArrivalDetails> arrivalsList)
        {
            Console.WriteLine($"At {arrivalsList.First().StationName}");
            foreach (var bus in arrivalsList)
            {
                string timeUnit = "minuets";
                if ((bus.TimeToStation / 60)! == 1)
                {
                    timeUnit = "minuet";
                }
                Console.WriteLine($"The {bus.LineName} " +
                                  $"towards {bus.DestinationName} " +
                                  $"will arrive in {bus.TimeToStation/60} {timeUnit}.");
            }
        }
    }
}
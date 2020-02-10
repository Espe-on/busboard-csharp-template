using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ArrivalDetails> busInfo = JsonRetriever
                .GetJson("https://api.tfl.gov.uk/", "StopPoint/490008660N/Arrivals")
                .OrderBy(arrivalDetails => arrivalDetails.TimeToStation)
                .Take(5)
                .ToList();
            ArrivalsPrinter.Print(busInfo);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the station ID.");
            string stationIdInput = Console.ReadLine();
            List<ArrivalDetails> busInfo = ArrivalsJsonRetriever
                .GetJson(stationIdInput);
            ArrivalsPrinter.Print(busInfo);
        }
    }
}
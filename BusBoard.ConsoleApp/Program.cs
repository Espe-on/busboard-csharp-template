using System;
using System.Collections.Generic;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Please enter your Postcode");
            Console.WriteLine();
            string postcode = Console.ReadLine(); 
            var postcodeDetails = PostcodeConverter.LonLat(postcode);
           var tflApiClient = new TflApiClient();
           List<StationIdDetails> busStops = tflApiClient.StationIdRetrieve(postcodeDetails.Latitude, postcodeDetails.Longitude);
           foreach (var bustop in busStops)
           {
               var arrivals = tflApiClient.FetchArrivalDetails(bustop.NaptanId);
               ArrivalsPrinter.Print(arrivals);
           }
        }
    }
}
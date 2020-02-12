using System;
using System.Collections.Generic;
using System.Linq;

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
           int counter = 0; 
           foreach (var arrivals in busStops.Select(bustop => tflApiClient.FetchArrivalDetails(bustop.NaptanId)))
           {
               ArrivalsPrinter.Print(arrivals);
               counter++;
               if (counter == 2)
               {
                   break;
               }
           }
        }
    }
}
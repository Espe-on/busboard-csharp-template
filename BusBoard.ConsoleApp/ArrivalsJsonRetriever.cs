using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    public class ArrivalsJsonRetriever
    {
        public static List<ArrivalDetails> GetJson(string stationId)
        {
            string baseUrl = "https://api.tfl.gov.uk/";
            string tflAppId = Environment.GetEnvironmentVariable("TFL_APP_ID");
            string tflKey = Environment.GetEnvironmentVariable("TFL_KEY");
            string requestPath = $"StopPoint/{stationId}/Arrivals?app_id={tflAppId}&app_key={tflKey}";
            var client = new RestClient(baseUrl); // directs client to TFL
            var request = new RestRequest(requestPath, DataFormat.Json); // sets format and type of data acquired
            var rawResponse = client.Get<List<ArrivalDetails>>(request); //pulls in response
            var response = rawResponse.Data
                .OrderBy(rawResponse => rawResponse.TimeToStation)
                .Take(5)
                .ToList();
            return response;
        }
    }
}
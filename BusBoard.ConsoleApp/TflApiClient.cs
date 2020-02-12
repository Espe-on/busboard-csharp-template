using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    public class TflApiClient
    {
        private readonly RestClient _client;
        private readonly string _appId;
        private readonly string _appKey;
        
        public TflApiClient()
        {
            _client = new RestClient("https://api.tfl.gov.uk/");
            _appId = Environment.GetEnvironmentVariable("TFL_APP_ID");
            _appKey = Environment.GetEnvironmentVariable("TFL_KEY");
        }
        
        public IEnumerable<ArrivalDetails> FetchArrivalDetails(string stationId)
        {
            var request = new RestRequest($"StopPoint/{stationId}/Arrivals");
            var response = MakeGetRequest<List<ArrivalDetails>>(request);

            return response
                .OrderBy(rawResponse => rawResponse.TimeToStation)
                .Take(5);
        }

        public List<StationIdDetails> StationIdRetrieve(string latitude, string longitude)
        {
            var request = new RestRequest($"StopPoint")
                .AddQueryParameter("stopTypes", "NaptanPublicBusCoachTram")
                .AddQueryParameter("radius", "290")
                .AddQueryParameter("lat", latitude)
                .AddQueryParameter("lon", longitude);
             
            var response = MakeGetRequest<StationIdInitialReturn>(request);
            try
            {
                var tester = response.StopPoints[0];
            }
            catch (System.ArgumentOutOfRangeException)
            {
                throw  new Exception("TFL BAD RESPONSE TO COORDINATES/POSTCODE");
            }
            return response.StopPoints;
        }

        private T MakeGetRequest<T>(IRestRequest request) where T : new()
        {
            request
                .AddQueryParameter("app_id", _appId)
                .AddQueryParameter("app_key", _appKey);
            return _client.Get<T>(request).Data;
        }
    }
}
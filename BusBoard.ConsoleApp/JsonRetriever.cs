using System.Collections.Generic;
using System.Security.Cryptography;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard
{
    public class JsonRetriever
    {
        public static List<ArrivalDetails> GetJson(string baseUrl, string requestPath)
        {
            var client = new RestClient(baseUrl); // directs client to TFL
            var request = new RestRequest(requestPath, DataFormat.Json); // sets format and type of data acquired
            var rawResponse = client.Get<List<ArrivalDetails>>(request); //pulls in response
            var response = rawResponse.Data;
            return response;
        }
    }
}
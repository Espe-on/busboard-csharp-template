using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class PostcodeConverter
    {
        private static bool PostcodeValidator(string postcode)
        {
            bool response = false; 
            string baseUrl = "https://api.postcodes.io/";
            string requestPath = $"postcodes/{postcode}/validate";
            var client = new RestClient(baseUrl); // directs client to TFL
            var request = new RestRequest(requestPath, DataFormat.Json); // sets format and type of data acquired
            var rawResponse = client.Get(request).Content;
            if (rawResponse.Contains("true"))
            {
                response = true;
            }
            else
            {
                response = false;
            }
            return response; 
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using RestSharp.Serialization.Xml;

namespace BusBoard
{
    public class PostcodeConverter
    {
        private static bool PostcodeValidator(string postcode)
        {
            bool response = false; 
            string baseUrl = "https://api.postcodes.io/";
            string requestPath = $"postcodes/{postcode}/validate";
            var client = new RestClient(baseUrl);
            var request = new RestRequest(requestPath, DataFormat.Json);
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

        public static string LonLat(string postcode)
        {
            if (PostcodeValidator(postcode) == true)
            {
                string baseUrl = "https://api.postcodes.io/";
                string requestPath = $"postcodes/{postcode}";
                var client = new RestClient(baseUrl);
                var request = new RestRequest(requestPath, DataFormat.Json);
                var rawResponse = client.Get<Return>(request);
                var postcodeDetails = rawResponse.Data.Result;
                string reponse = $"{postcodeDetails.Longitude},{postcodeDetails.Latitude}";
                return reponse;
            }
            else
            {
                string response = "ERROR INVALID POSTCODE";
                //put in better errors here
            }

            return ":(";
        }
    }
}
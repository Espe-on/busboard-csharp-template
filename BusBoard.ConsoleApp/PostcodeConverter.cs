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

        public static PostcodeDetails LonLat(string postcode)
        {
            if (!PostcodeValidator(postcode))
            {
                throw new Exception("ERROR INVALID POSTCODE");
            }
            
            string baseUrl = "https://api.postcodes.io/";
            string requestPath = $"postcodes/{postcode}";
            var client = new RestClient(baseUrl);
            var request = new RestRequest(requestPath, DataFormat.Json);
            var rawResponse = client.Get<PostcodeInitialReturn>(request);
            return rawResponse.Data.Result;
        }
    }
}
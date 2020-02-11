using RestSharp;

namespace BusBoard
{
    public class PostcodeIoClient
    {
        private readonly RestClient _client;

        public PostcodeIoClient()
        {
            _client = new RestClient("https://api.postcodes.io/");
        }

        private bool ValidatePostCode (string postcode)
        {
            bool response = false;
            var request = new RestRequest($"postcodes/{postcode}/validate");
            var rawResponse = _client.Get(request).Content;
            if (rawResponse.Contains("true"))
            {
                response = true;
            }

            return response;
        }
    }
}
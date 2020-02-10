using System.Security.Cryptography;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard
{
    public class JsonRetriever
    {
        public static IRestResponse GetJson(string baseUrl, string username, string password, string requestPath)
        {
            var client = new RestClient(baseUrl); // directs client to TFL
            client.Authenticator = new HttpBasicAuthenticator(username, password);
            var request = new RestRequest(requestPath, DataFormat.Json); // sets format and type of data acquired
            var response = client.Get(request); //pulls in response
            return response;
        }
    }
}
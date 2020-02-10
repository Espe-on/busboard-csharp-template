namespace BusBoard
{
    public class ApiDetails
    {
        public string Username;
        public string Password;
        public string Url;
        public string RequestPath;

        public ApiDetails(string username, string password, string url, string requestPath)
        {
            Username = username;
            Password = password;
            Url = url;
            RequestPath = requestPath;
        }
    }
}
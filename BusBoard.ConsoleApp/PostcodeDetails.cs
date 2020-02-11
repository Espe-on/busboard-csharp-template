namespace BusBoard
{
    public class PostcodeDetails
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public PostcodeDetails(string longitude, string latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
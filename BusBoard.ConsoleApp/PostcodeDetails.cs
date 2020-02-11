namespace BusBoard
{
    public class PostcodeInitialReturn
    {
        public int Status { get; set; }
        public PostcodeDetails Result { get; set; }
    }
    public class PostcodeDetails
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
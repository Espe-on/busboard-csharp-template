using System.Collections.Generic;

namespace BusBoard
{
    public class StationIdInitialReturn
    {
        public List<StationIdDetails> StopPoints { get; set; }
    }
    public class StationIdDetails
    {
        public string NaptanId { get; set; }
    }
}
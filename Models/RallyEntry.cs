using System.Collections.Generic;

namespace DotnetWebAPI.Models
{
    public class RallyEntry
    {
        public int RallyEntryId { get; set; }
        public int StartingNumber { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int RallyId { get; set; }
        public Rally Rally { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
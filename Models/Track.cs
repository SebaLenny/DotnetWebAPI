using System.Collections.Generic;

namespace DotnetWebAPI.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public ICollection<Stage> Stages { get; set; }
    }
}
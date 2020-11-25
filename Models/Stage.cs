using System.Collections.Generic;

namespace DotnetWebAPI.Models
{
    public class Stage
    {
        public int StageId { get; set; }
        public int RallyId { get; set; }
        public Rally Rally { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int? ConditionsId { get; set; }
        public Conditions Conditions { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
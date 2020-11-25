using System;

namespace DotnetWebAPI.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public TimeSpan Time { get; set; }
        public bool DNF { get; set; }
        public int RallyEntryId { get; set; }
        public RallyEntry RallyEntry { get; set; }
        public int StageId { get; set; }
        public Stage Stage { get; set; }
    }
}
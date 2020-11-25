using System;
using System.Collections.Generic;

namespace DotnetWebAPI.Models
{
    public class Rally
    {
        public int RallyId { get; set; }
        public string RallyName { get; set; }
        public DateTime EventDate { get; set; }
        public int? CarCategoryId { get; set; }
        public CarCategory CarCategory { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public ICollection<RallyEntry> RallyEntries { get; set; }
        public ICollection<Stage> Stages { get; set; }
    }
}
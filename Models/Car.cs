using System.Collections.Generic;

namespace DotnetWebAPI.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int? CarCategoryId { get; set; }
        public CarCategory CarCategory { get; set; }
        public ICollection<RallyEntry> RallyEntries { get; set; }
    }
}
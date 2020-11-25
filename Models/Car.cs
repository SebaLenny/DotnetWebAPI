using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotnetWebAPI.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [Required]
        public string CarName { get; set; }
        public ICollection<CarCategory> CarCategory { get; set; }
        public ICollection<RallyEntry> RallyEntries { get; set; }
    }
}
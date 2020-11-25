using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotnetWebAPI.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        [Required]
        public string DriverNick { get; set; }
        [Range(1, 99)]
        public int FavouriteNumber { get; set; }
        public DateTime JoinedDate { get; set; }
        public ICollection<RallyEntry> RallyEntries { get; set; }
    }
}
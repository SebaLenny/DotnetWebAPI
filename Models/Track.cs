using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotnetWebAPI.Models
{
    public class Track
    {
        public int TrackId { get; set; }
        [Required]
        public string TrackName { get; set; }
        public ICollection<Stage> Stages { get; set; }
    }
}
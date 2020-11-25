using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotnetWebAPI.Models
{
    public class Conditions
    {
        public int ConditionsId { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Stage> Stages { get; set; }
    }
}
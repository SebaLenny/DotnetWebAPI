using System.Collections.Generic;

namespace DotnetWebAPI.Models
{
    public class Conditions
    {
        public int ConditionsId { get; set; }
        public string Description { get; set; }
        public ICollection<Stage> Stages { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotnetWebAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Rally> Rallies { get; set; }
    }
}
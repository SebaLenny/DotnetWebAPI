using System.Collections.Generic;

namespace DotnetWebAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public ICollection<Rally> Rallies { get; set; }
    }
}
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DotnetWebAPI.Models{
    public class CarCategory
    {
        public int CarCategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Rally> Rallies { get; set; }
    }
}
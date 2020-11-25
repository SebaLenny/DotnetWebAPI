using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DotnetWebAPI.Models{
    public class CarCategory
    {
        public int CarCategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Rally> Rallies { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace DotnetWebAPI.Models.DTOs
{
    public class DriverCreateDto
    {
        public string DriverNick { get; set; }
        [Range(1, 99)]
        public int FavouriteNumber { get; set; }
    }
}
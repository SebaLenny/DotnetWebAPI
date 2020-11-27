using System.Collections.Generic;
using System.Threading.Tasks;
using DotnetWebAPI.Models;
using DotnetWebAPI.Models.DTOs;

namespace DotnetWebAPI.Services
{
    public interface IDriverService
    {
        Task<List<Driver>> GetDrivers();
        Task<Driver> GetDriver(int driverId);
        Task<Driver> GetDriver(string nick);
        Task<Driver> CreateDriver(DriverCreateDto driverCreate);
        Task<Driver> UpdateDriver(DriverCreateDto driverCreate);
    }
}
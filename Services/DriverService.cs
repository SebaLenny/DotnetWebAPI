using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DotnetWebAPI.Models;
using DotnetWebAPI.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DotnetWebAPI.Services
{
    public class DriverService : IDriverService
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;
        public DriverService(
            AppDbContext appDbContext,
            IMapper mapper
        )
        {
            this.mapper = mapper;
            this.appDbContext = appDbContext;
        }

        public async Task<Driver> GetDriver(int driverId)
        {
            return await appDbContext.Drivers.FirstOrDefaultAsync(d => d.DriverId == driverId);
        }

        public async Task<Driver> GetDriver(string nick)
        {
            return await appDbContext.Drivers.FirstOrDefaultAsync(d => d.DriverNick == nick);
        }

        public async Task<List<Driver>> GetDrivers()
        {
            return await appDbContext.Drivers.ToListAsync();
        }

        public async Task<Driver> CreateDriver(DriverCreateDto driverCreate)
        {
            var newDriver = mapper.Map<Driver>(driverCreate);
            newDriver.JoinedDate = DateTime.Now;
            var restult = await appDbContext.AddAsync(newDriver);
            return restult.Entity;
        }

        public async Task<Driver> UpdateDriver(DriverCreateDto driverData)
        {
            var driver = await GetDriver(driverData.DriverNick);
            if (driver == null) return null;
            driver = mapper.Map(driverData, driver);
            appDbContext.Update<Driver>(driver);
            return driver;
        }
    }
}
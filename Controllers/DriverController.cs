using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetWebAPI.Models;
using DotnetWebAPI.Models.DTOs;
using DotnetWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotnetWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IDriverService driverService;
        private readonly IUniversalService universalService;

        public DriverController(
            AppDbContext appDbContext,
            IDriverService driverService,
            IUniversalService universalService
        )
        {
            this.driverService = driverService;
            this.universalService = universalService;
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetDrivers()
        {
            var drivers = await driverService.GetDrivers();
            return Ok(drivers);
        }

        [HttpGet("id/{driverId}")]
        public async Task<IActionResult> GetDriver(int driverId)
        {
            var driver = await driverService.GetDriver(driverId);
            return Ok(driver);
        }

        [HttpGet("nick/{nick}")]
        public async Task<IActionResult> GetDriver(string nick)
        {
            var driver = await driverService.GetDriver(nick);
            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver(DriverCreateDto createDto)
        {
            var driver = await driverService.CreateDriver(createDto);
            if (driver != null)
            {
                var result = await universalService.SaveAll();
                if (result)
                    return Ok(driver);
            }
            return BadRequest("Unable to create driver");
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateDriver(DriverCreateDto updateDto)
        {
            var driver = await driverService.UpdateDriver(updateDto);
            if (driver != null)
            {
                if (await universalService.SaveAll())
                {
                    return Ok(driver);
                }
            }
            return BadRequest("Could not update driver");
        }
    }
}
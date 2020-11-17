using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotnetWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokeController : Controller
    {
        private readonly AppDbContext appDbContext;
        public JokeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetJokes()
        {
            var jokes = await appDbContext.Jokes
                .Include(j => j.Category)
                .ToListAsync();
            return Ok(jokes);
        }
    }
}
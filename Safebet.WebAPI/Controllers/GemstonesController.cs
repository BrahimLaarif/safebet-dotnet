using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Safebet.WebAPI.Data.Repositories;
using Safebet.WebAPI.Models;

namespace Safebet.WebAPI.Controllers
{
    [Route("api/gemstones")]
    [ApiController]
    public class GemstonesController : ControllerBase
    {
        private readonly IApplicationRepository repository;
        private readonly IConfiguration configuration;
        private List<string> gemstones;

        public GemstonesController(IApplicationRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
            this.gemstones = configuration.GetSection("Gemstones").Get<List<string>>();
        }

        [HttpGet("today", Name = nameof(GetTodayGemstones))]
        public async Task<IActionResult> GetTodayGemstones()
        {
            var date = DateTime.Now.Date;
            var filter = new MatchFilter() { Gemstones = string.Join(",", gemstones) };

            var matches = await repository.GetMatches(date, filter);

            return Ok(matches);
        }

        [HttpGet("upcoming", Name = nameof(GetUpcomingGemstones))]
        public async Task<IActionResult> GetUpcomingGemstones()
        {
            var startDate = DateTime.Now.Date;
            var endDate = DateTime.Now.Date.AddDays(7);
            var filter = new MatchFilter() { Gemstones = string.Join(",", gemstones) };

            var groups = await repository.GetMatchesGroupedByDate(startDate, endDate, filter);

            return Ok(groups);
        }
    }
}
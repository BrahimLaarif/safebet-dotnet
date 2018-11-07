using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Safebet.WebAPI.Data;
using Safebet.WebAPI.Utilities;

namespace Safebet.WebAPI.Controllers
{
    [Route("api/gemstones/statistics")]
    [ApiController]
    public class GemstonesStatisticsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;

        public GemstonesStatisticsController(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetGemstonesStatistics()
        {
            var gemstones = configuration.GetSection("Gemstones").Get<List<string>>();

            var matches = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => m.LastPrediction.Gemstone != null)
                .Where(m => m.Result != null)
                .OrderBy(m => m.Id)
                .ToListAsync();

            var gemstonesStatistics = new GemstonesStatisticsBuilder(matches).BuildGemstonesStatistics(gemstones);

            return Ok(gemstonesStatistics);
        }

        [HttpGet("{gemstonesQuery}", Name = nameof(GetGemstoneStatisticsByGemstones))]
        public async Task<IActionResult> GetGemstoneStatisticsByGemstones(string gemstonesQuery)
        {
            var gemstones = gemstonesQuery.Split(",").ToList();

            var matches = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => m.LastPrediction.Gemstone != null)
                .Where(m => m.Result != null)
                .OrderBy(m => m.Id)
                .ToListAsync();

            var gemstoneStatistics = new GemstonesStatisticsBuilder(matches).BuildGemstoneStatistics(gemstones);

            return Ok(gemstoneStatistics);
        }
    }
}
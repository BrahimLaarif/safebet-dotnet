using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Safebet.WebAPI.Data;
using Safebet.WebAPI.Extensions;
using Safebet.WebAPI.Models;
using Safebet.WebAPI.Resources;
using Safebet.WebAPI.Utilities;

namespace Safebet.WebAPI.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MatchesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMatches([FromQuery] MatchFilter filter)
        {
            var matches = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => string.IsNullOrEmpty(filter.Name) || m.Name.Contains(filter.Name))
                .Where(m => string.IsNullOrEmpty(filter.EventName) || m.EventName.Equals(filter.EventName))
                .Where(m => !filter.Date.HasValue || m.StartDate.Date.Equals(filter.Date))
                .Where(m => !filter.StartDate.HasValue || m.StartDate.Date >= filter.StartDate)
                .Where(m => !filter.EndDate.HasValue || m.StartDate.Date <= filter.EndDate)
                .OrderBy(m => m.StartDate.Date)
                .ThenBy(m => m.EventName)
                .Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize)
                .ToListAsync();

            var result = mapper.Map<List<Match>, IEnumerable<CardMatchResource>>(matches);

            return Ok(result);
        }

        [HttpGet("{id}", Name = nameof(GetMatch))]
        public async Task<IActionResult> GetMatch(int id)
        {
            var match = await context.Matches
                .Include(m => m.TimePoints)
                .Include(m => m.Predictions)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (match == null)
            {
                return NotFound();
            }

            var result = mapper.Map<Match, DetailsMatchResource>(match);

            return Ok(result);
        }

        [HttpGet("today", Name = nameof(GetTodayMatches))]
        public async Task<IActionResult> GetTodayMatches([FromQuery] TodayMatchFilter filter)
        {
            var matches = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => string.IsNullOrEmpty(filter.Name) || m.Name.Contains(filter.Name))
                .Where(m => string.IsNullOrEmpty(filter.EventName) || m.EventName.Equals(filter.EventName))
                .Where(m => m.StartDate.Date.Equals(DateTime.Now.Date))
                .OrderBy(m => m.EventName)
                .Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize)
                .ToListAsync();
            
            var result = mapper.Map<List<Match>, IEnumerable<CardMatchResource>>(matches);

            return Ok(result);
        }

        [HttpGet("gemstone", Name = nameof(GetMatchesWithGemstone))]
        public async Task<IActionResult> GetMatchesWithGemstone([FromQuery] MatchFilter filter)
        {
            var matches = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => m.LastPrediction.Gemstone != null)
                .Where(m => string.IsNullOrEmpty(filter.Name) || m.Name.Contains(filter.Name))
                .Where(m => string.IsNullOrEmpty(filter.EventName) || m.EventName.Equals(filter.EventName))
                .Where(m => !filter.Date.HasValue || m.StartDate.Date.Equals(filter.Date))
                .Where(m => !filter.StartDate.HasValue || m.StartDate.Date >= filter.StartDate)
                .Where(m => !filter.EndDate.HasValue || m.StartDate.Date <= filter.EndDate)
                .OrderBy(m => m.StartDate.Date)
                .ThenBy(m => m.EventName)
                .Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize)
                .ToListAsync();
            
            var result = mapper.Map<List<Match>, IEnumerable<CardMatchResource>>(matches);

            return Ok(result);
        }

        [HttpGet("gemstone/{gemstonesString}", Name = nameof(GetMatchesWithGemstoneByGemstones))]
        public async Task<IActionResult> GetMatchesWithGemstoneByGemstones(string gemstonesString, [FromQuery] MatchFilter filter)
        {
            var gemstones = gemstonesString.Split(",").ToList();

            var matches = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => gemstones.Contains(m.LastPrediction.Gemstone))
                .Where(m => string.IsNullOrEmpty(filter.Name) || m.Name.Contains(filter.Name))
                .Where(m => string.IsNullOrEmpty(filter.EventName) || m.EventName.Equals(filter.EventName))
                .Where(m => !filter.Date.HasValue || m.StartDate.Date.Equals(filter.Date))
                .Where(m => !filter.StartDate.HasValue || m.StartDate.Date >= filter.StartDate)
                .Where(m => !filter.EndDate.HasValue || m.StartDate.Date <= filter.EndDate)
                .OrderBy(m => m.StartDate.Date)
                .ThenBy(m => m.EventName)
                .Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize)
                .ToListAsync();
            
            var result = mapper.Map<List<Match>, IEnumerable<CardMatchResource>>(matches);

            return Ok(result);
        }
    }
}
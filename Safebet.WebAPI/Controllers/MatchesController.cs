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
using Safebet.WebAPI.Utilities;

namespace Safebet.WebAPI.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public MatchesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMatches([FromQuery] MatchFilter filter)
        {
            var matches = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => !filter.Date.HasValue || m.StartDate.Date.Equals(filter.Date))
                .OrderBy(m => m.Id)
                .Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize)
                .ToListAsync();

            return Ok(matches);
        }

        [HttpGet("{id}", Name = nameof(GetMatch))]
        public async Task<IActionResult> GetMatch(int id)
        {
            var match = await context.Matches
                .Include(m => m.TimePoints)
                .Include(m => m.Predictions)
                .Include(m => m.LastPrediction)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        [HttpGet("gemstone", Name = nameof(GetMatchesWithGemstone))]
        public async Task<IActionResult> GetMatchesWithGemstone([FromQuery] MatchFilter filter)
        {
            var matches = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => !filter.Date.HasValue || m.StartDate.Date.Equals(filter.Date))
                .Where(m => string.IsNullOrEmpty(filter.EventName) || m.EventName.Equals(filter.EventName))
                .Where(m => m.LastPrediction.Gemstone != null)
                .OrderBy(m => m.Id)
                .Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize)
                .ToListAsync();
            
            return Ok(matches);
        }

        [HttpGet("gemstone/{gemstonesQuery}", Name = nameof(GetMatchesWithGemstoneByGemstones))]
        public async Task<IActionResult> GetMatchesWithGemstoneByGemstones(string gemstonesQuery, [FromQuery] MatchFilter filter)
        {
            var gemstones = gemstonesQuery.Split(",").ToList();

            var matches = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => !filter.Date.HasValue || m.StartDate.Date.Equals(filter.Date))
                .Where(m => string.IsNullOrEmpty(filter.EventName) || m.EventName.Equals(filter.EventName))
                .Where(m => gemstones.Contains(m.LastPrediction.Gemstone))
                .OrderBy(m => m.Id)
                .Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize)
                .ToListAsync();

            return Ok(matches);
        }

        [HttpGet("gemstone/group/by/date", Name = nameof(GetMatchesWithGemstoneGroupByDate))]
        public async Task<IActionResult> GetMatchesWithGemstoneGroupByDate([FromQuery] GroupFilter filter)
        {
            var groups = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => m.LastPrediction.Gemstone != null)
                .GroupBy(m => m.StartDate.Date)
                .OrderBy(g => g.Key)
                .Select(g => new DateGroup() 
                    {
                        Date = g.Key,
                        Count = g.Count(),
                        Matches = g.OrderBy(m => m.Id).Take(10).ToList()
                    }
                )
                .Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize)
                .ToListAsync();
            
            return Ok(groups);
        }

        [HttpGet("gemstone/group/by/eventName", Name = nameof(GetMatchesWithGemstoneGroupByEventName))]
        public async Task<IActionResult> GetMatchesWithGemstoneGroupByEventName([FromQuery] GroupFilter filter)
        {
            var groups = await context.Matches
                .Include(m => m.LastPrediction)
                .Where(m => m.LastPrediction.Gemstone != null)
                .GroupBy(m => m.EventName)
                .OrderBy(g => g.Key)
                .Select(g => new EventNameGroup() 
                    {
                        EventName = g.Key,
                        Count = g.Count(),
                        Matches = g.OrderBy(m => m.Id).Take(10).ToList()
                    }
                )
                .Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize)
                .ToListAsync();
            
            return Ok(groups);
        }
    }
}
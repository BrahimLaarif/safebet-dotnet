using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Safebet.WebAPI.Data;
using Safebet.WebAPI.Data.Repositories;
using Safebet.WebAPI.Extensions;
using Safebet.WebAPI.Models;
using Safebet.WebAPI.Utilities;

namespace Safebet.WebAPI.Controllers
{
    [Route("api/matches")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IApplicationRepository repository;

        public MatchesController(IApplicationRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("date/{date}", Name = nameof(GetMatchesByDate))]
        public async Task<IActionResult> GetMatchesByDate(DateTime date, [FromQuery] MatchFilter filter)
        {
            var matches = await repository.GetMatchesByDate(date, filter);

            return Ok(matches);
        }

        [HttpGet("period/{startDate}/{endDate}", Name = nameof(GetMatchesByPeriod))]
        public async Task<IActionResult> GetMatchesByPeriod(DateTime startDate, DateTime endDate, [FromQuery] MatchFilter filter)
        {
            var matches = await repository.GetMatchesByPeriod(startDate, endDate, filter);

            return Ok(matches);
        }

        [HttpGet("upcoming", Name = nameof(GetUpcomingMatches))]
        public async Task<IActionResult> GetUpcomingMatches([FromQuery] MatchFilter filter)
        {
            var startDate = DateTime.Now.Date;
            var endDate = DateTime.Now.Date.AddDays(7);
            
            var groups = await repository.GetMatchesGroupedByDate(startDate, endDate, filter);

            return Ok(groups);
        }

        [HttpGet("view/{id}", Name = nameof(GetMatch))]
        public async Task<IActionResult> GetMatch(int id)
        {
            var match = await repository.GetMatch(id);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        [HttpGet("view/{id}/snapshot/{snapshot}", Name = nameof(GetMatchSnapshot))]
        public async Task<IActionResult> GetMatchSnapshot(int id, TimeSpan snapshot)
        {
            var match = await repository.GetMatch(id, snapshot);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }
    }
}
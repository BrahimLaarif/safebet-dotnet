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

        [HttpGet("date/{date}", Name = nameof(GetMatches))]
        public async Task<IActionResult> GetMatches(DateTime date, [FromQuery] MatchFilter filter)
        {
            var matches = await repository.GetMatches(date, filter);

            return Ok(matches);
        }

        [HttpGet("date/{date}/snapshot/{snapshot}", Name = nameof(GetMatchesSnapshot))]
        public async Task<IActionResult> GetMatchesSnapshot(DateTime date, TimeSpan snapshot, [FromQuery] MatchFilter filter)
        {
            var matches = await repository.GetMatchesSnapshot(date, snapshot, filter);

            return Ok(matches);
        }

        [HttpGet("period/{startDate}/{endDate}", Name = nameof(GetMatchesGroupedByDate))]
        public async Task<IActionResult> GetMatchesGroupedByDate(DateTime startDate, DateTime endDate, [FromQuery] MatchFilter filter)
        {
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
            var match = await repository.GetMatchSnapshot(id, snapshot);

            if (match == null)
            {
                return NotFound();
            }

            return Ok(match);
        }
    }
}
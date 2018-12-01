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

        [HttpGet("today", Name = nameof(GetTodayMatches))]
        public async Task<IActionResult> GetTodayMatches([FromQuery] MatchFilter filter)
        {
            var today = new DateTime(2018, 11, 2, 18, 0, 0);

            var matches = await repository.GetTodayMatches(today, filter);

            return Ok(matches);
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
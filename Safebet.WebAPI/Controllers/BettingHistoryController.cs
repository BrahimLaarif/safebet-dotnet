using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Safebet.WebAPI.Data;
using Safebet.WebAPI.Data.Repositories;
using Safebet.WebAPI.Models;
using Safebet.WebAPI.Utilities;

namespace Safebet.WebAPI.Controllers
{
    [Route("api/bettingHistory")]
    [ApiController]
    public class BettingHistoryController : ControllerBase
    {
        private readonly IApplicationRepository repository;

        public BettingHistoryController(IApplicationRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("period/{startDate}/{endDate}")]
        public async Task<IActionResult> GetBettingHistory(DateTime startDate, DateTime endDate, [FromQuery] MatchFilter filter)
        {
            var groups = await repository.GetMatchesGroupedByDate(startDate, endDate, filter);

            var bettingHistory = new BettingHistoryBuilder(groups).BuildBettingHistory();

            return Ok(bettingHistory);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Safebet.WebAPI.Models;

namespace Safebet.WebAPI.Data.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ItemMatch>> GetBestRiskFreeMatches(DateTime date)
        {
            return await context.Matches
                .Where(m => m.KickoffDate.Date.Equals(date))
                .Select(m => new ItemMatch() {
                    Id = m.Id,
                    EventName = m.EventName,
                    KickoffDate = m.KickoffDate,
                    Name = m.Name,
                    Result = m.Result,
                    Prediction = m.Predictions
                        .OrderByDescending(p => p.CreationDate)
                        .FirstOrDefault()
                })
                .Where(m => m.Prediction.PredictedSafeProba >= 0.66)
                .OrderByDescending(m => m.Prediction.PredictedSafeProba)
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemMatch>> GetMatches(DateTime date, MatchFilter filter)
        {
            return await context.Matches
                .Where(m => m.KickoffDate.Date.Equals(date))
                .Where(m => string.IsNullOrEmpty(filter.Name) || m.Name.Contains(filter.Name))
                .Where(m => string.IsNullOrEmpty(filter.Events) || filter.Events.Contains(m.EventName))
                .OrderBy(m => m.KickoffDate)
                // .ThenBy(m => m.EventName)
                .Select(m => new ItemMatch() {
                    Id = m.Id,
                    EventName = m.EventName,
                    KickoffDate = m.KickoffDate,
                    Name = m.Name,
                    Result = m.Result,
                    Prediction = m.Predictions
                        .OrderByDescending(p => p.CreationDate)
                        .FirstOrDefault()
                })
                .Where(m => string.IsNullOrEmpty(filter.Gemstones) || filter.Gemstones.Contains(m.Prediction.Gemstone))
                .ToListAsync();
        }

        public async Task<IEnumerable<ItemMatch>> GetMatchesSnapshot(DateTime date, TimeSpan snapshot, MatchFilter filter)
        {
            return await context.Matches
                .Where(m => m.KickoffDate.Date.Equals(date))
                .Where(m => m.KickoffDate >= m.KickoffDate.Date.AddHours(snapshot.Hours).AddMinutes(snapshot.Minutes).AddSeconds(snapshot.Seconds))
                .Where(m => string.IsNullOrEmpty(filter.Name) || m.Name.Contains(filter.Name))
                .Where(m => string.IsNullOrEmpty(filter.Events) || filter.Events.Contains(m.EventName))
                .OrderBy(m => m.KickoffDate)
                // .ThenBy(m => m.EventName)
                .Select(m => new ItemMatch() {
                    Id = m.Id,
                    EventName = m.EventName,
                    KickoffDate = m.KickoffDate,
                    Name = m.Name,
                    Result = m.Result,
                    Prediction = m.Predictions
                        .Where(p => p.CreationDate <= m.KickoffDate.Date.AddHours(snapshot.Hours).AddMinutes(snapshot.Minutes).AddSeconds(snapshot.Seconds))
                        .OrderByDescending(p => p.CreationDate)
                        .FirstOrDefault()
                })
                .Where(m => string.IsNullOrEmpty(filter.Gemstones) || filter.Gemstones.Contains(m.Prediction.Gemstone))
                .ToListAsync();
        }

        public async Task<IEnumerable<DateGroup>> GetMatchesGroupedByDate(DateTime startDate, DateTime endDate, MatchFilter filter)
        {
            var matches = await context.Matches
                .Where(m => m.KickoffDate.Date >= startDate)
                .Where(m => m.KickoffDate.Date <= endDate)
                .Where(m => string.IsNullOrEmpty(filter.Name) || m.Name.Contains(filter.Name))
                .Where(m => string.IsNullOrEmpty(filter.Events) || filter.Events.Contains(m.EventName))
                .OrderBy(m => m.KickoffDate)
                // .ThenBy(m => m.EventName)
                .Select(m => new ItemMatch() {
                    Id = m.Id,
                    EventName = m.EventName,
                    KickoffDate = m.KickoffDate,
                    Name = m.Name,
                    Result = m.Result,
                    Prediction = m.Predictions
                        .OrderByDescending(p => p.CreationDate)
                        .FirstOrDefault()
                })
                .Where(m => string.IsNullOrEmpty(filter.Gemstones) || filter.Gemstones.Contains(m.Prediction.Gemstone))
                .ToListAsync();
            
            return matches
                .GroupBy(m => m.KickoffDate.Date)
                .Select(g => new DateGroup() {
                    Date = g.Key,
                    Count = g.Count(),
                    Matches = g.ToList()
                })
                .ToList();
        }

        public async Task<DetailMatch> GetMatch(int id)
        {
            return await context.Matches
                .Select(m => new DetailMatch() {
                    Id = m.Id,
                    EventName = m.EventName,
                    KickoffDate = m.KickoffDate,
                    Name = m.Name,
                    Result = m.Result,
                    TimePoints = m.TimePoints
                        .ToList(),
                    Predictions = m.Predictions
                        .ToList(),
                    Prediction = m.Predictions
                        .OrderByDescending(p => p.CreationDate)
                        .FirstOrDefault()
                })
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<DetailMatch> GetMatchSnapshot(int id, TimeSpan snapshot)
        {
            return await context.Matches
                .Where(m => m.KickoffDate >= m.KickoffDate.Date.AddHours(snapshot.Hours).AddMinutes(snapshot.Minutes).AddSeconds(snapshot.Seconds))
                .Select(m => new DetailMatch() {
                    Id = m.Id,
                    EventName = m.EventName,
                    KickoffDate = m.KickoffDate,
                    Name = m.Name,
                    Result = m.Result,
                    TimePoints = m.TimePoints
                        .Where(t => t.CreationDate <= m.KickoffDate.Date.AddHours(snapshot.Hours).AddMinutes(snapshot.Minutes).AddSeconds(snapshot.Seconds))
                        .ToList(),
                    Predictions = m.Predictions
                        .Where(p => p.CreationDate <= m.KickoffDate.Date.AddHours(snapshot.Hours).AddMinutes(snapshot.Minutes).AddSeconds(snapshot.Seconds))
                        .ToList(),
                    Prediction = m.Predictions
                        .Where(p => p.CreationDate <= m.KickoffDate.Date.AddHours(snapshot.Hours).AddMinutes(snapshot.Minutes).AddSeconds(snapshot.Seconds))
                        .OrderByDescending(p => p.CreationDate)
                        .FirstOrDefault()
                })
                .SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
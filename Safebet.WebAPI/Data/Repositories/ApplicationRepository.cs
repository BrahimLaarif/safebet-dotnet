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

        public async Task<IEnumerable<ItemMatch>> GetMatches(DateTime date, MatchFilter filter)
        {
            return await context.Matches
                .Where(m => m.KickoffDate.Date.Equals(date))
                .Where(m => string.IsNullOrEmpty(filter.Name) || m.Name.Contains(filter.Name))
                .Where(m => string.IsNullOrEmpty(filter.Events) || filter.Events.Contains(m.EventName))
                .OrderBy(m => m.KickoffDate)
                .ThenBy(m => m.EventName)
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

        public async Task<IEnumerable<DateGroup>> GetMatchesGroupedByDate(DateTime startDate, DateTime endDate, MatchFilter filter)
        {
            var matches = await context.Matches
                .Where(m => m.KickoffDate.Date >= startDate)
                .Where(m => m.KickoffDate.Date <= endDate)
                .Where(m => string.IsNullOrEmpty(filter.Name) || m.Name.Contains(filter.Name))
                .Where(m => string.IsNullOrEmpty(filter.Events) || filter.Events.Contains(m.EventName))
                .OrderBy(m => m.KickoffDate)
                .ThenBy(m => m.EventName)
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
                .Where(m => m.Prediction != null)
                .GroupBy(m => m.KickoffDate.Date)
                .Select(g => new DateGroup() {
                    Date = g.Key,
                    Count = g.Count(),
                    Matches = g.ToList()
                })
                .ToList();
        }

        public async Task<DetailMatch> GetMatch(int id, TimeSpan? snapshot = null)
        {
            return await context.Matches
                .Select(m => new DetailMatch() {
                    Id = m.Id,
                    EventName = m.EventName,
                    KickoffDate = m.KickoffDate,
                    Name = m.Name,
                    Result = m.Result,
                    TimePoints = m.TimePoints
                        .Where(t => !snapshot.HasValue || t.CreationDate <= m.KickoffDate.Date.AddHours(snapshot.Value.Hours).AddMinutes(snapshot.Value.Minutes).AddSeconds(snapshot.Value.Seconds))
                        .ToList(),
                    Predictions = m.Predictions
                        .Where(p => !snapshot.HasValue || p.CreationDate <= m.KickoffDate.Date.AddHours(snapshot.Value.Hours).AddMinutes(snapshot.Value.Minutes).AddSeconds(snapshot.Value.Seconds))
                        .ToList(),
                    Prediction = m.Predictions
                        .Where(p => !snapshot.HasValue || p.CreationDate <= m.KickoffDate.Date.AddHours(snapshot.Value.Hours).AddMinutes(snapshot.Value.Minutes).AddSeconds(snapshot.Value.Seconds))
                        .OrderByDescending(p => p.CreationDate)
                        .FirstOrDefault()
                })
                .SingleOrDefaultAsync(m => m.Id == id);
        }
    }
}
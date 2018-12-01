using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Safebet.WebAPI.Models;

namespace Safebet.WebAPI.Data.Repositories
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<ItemMatch>> GetMatches(DateTime date, MatchFilter filter);
        Task<IEnumerable<ItemMatch>> GetTodayMatches(DateTime today, MatchFilter filter);
        Task<IEnumerable<DateGroup>> GetMatchesGroupedByDate(DateTime startDate, DateTime endDate, MatchFilter filter);
        Task<DetailMatch> GetMatch(int id, TimeSpan? snapshot = null);
    }
}

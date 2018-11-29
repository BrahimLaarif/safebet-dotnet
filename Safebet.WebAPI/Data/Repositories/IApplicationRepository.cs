using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Safebet.WebAPI.Models;

namespace Safebet.WebAPI.Data.Repositories
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<ItemMatch>> GetMatchesByDate(DateTime date, MatchFilter filter);
        Task<IEnumerable<ItemMatch>> GetMatchesByPeriod(DateTime startDate, DateTime endDate, MatchFilter filter);
        Task<IEnumerable<DateGroup>> GetMatchesGroupedByDate(DateTime startDate, DateTime endDate, MatchFilter filter);
        Task<DetailMatch> GetMatch(int id, TimeSpan? snapshot);
    }
}
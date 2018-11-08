using System;

namespace Safebet.WebAPI.Models
{
    public class MatchFilter
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string EventName { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public MatchFilter()
        {
            Page = 1;
            PageSize = 10;
        }
    }
}
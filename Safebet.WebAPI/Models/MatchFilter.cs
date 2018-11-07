using System;

namespace Safebet.WebAPI.Models
{
    public class MatchFilter
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public DateTime? Date { get; set; }
        public string EventName { get; set; }

        public MatchFilter()
        {
            Page = 1;
            PageSize = 10;
        }
    }
}
namespace Safebet.WebAPI.Models
{
    public class TodayMatchFilter
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string EventName { get; set; }

        public TodayMatchFilter()
        {
            Page = 1;
            PageSize = 10;
        }
    }
}
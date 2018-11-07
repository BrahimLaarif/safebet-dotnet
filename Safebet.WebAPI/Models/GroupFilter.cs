using System;

namespace Safebet.WebAPI.Models
{
    public class GroupFilter
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GroupFilter()
        {
            Page = 1;
            PageSize = 10;
        }
    }
}
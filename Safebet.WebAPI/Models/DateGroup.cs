using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Safebet.WebAPI.Models
{
    public class DateGroup
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public virtual ICollection<ItemMatch> Matches { get; set; }

        public DateGroup()
        {
            Matches = new Collection<ItemMatch>();
        }
    }
}
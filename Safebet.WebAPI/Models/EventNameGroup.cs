using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Safebet.WebAPI.Models
{
    public class EventNameGroup
    {
        public string EventName { get; set; }
        public int Count { get; set; }
        public ICollection<Match> Matches { get; set; }

        public EventNameGroup()
        {
            Matches = new Collection<Match>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Safebet.WebAPI.Models
{
    public class Match
    {
        public int Id { get; set; }

        public string Hash { get; set; }

        [Required]
        public string EventName { get; set; }

        public DateTime StartDate { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<TimePoint> TimePoints { get; set; }

        public string LastTimePointHash { get; set; }

        public bool Processed { get; set; }

        public string Result { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public Match()
        {
            TimePoints = new Collection<TimePoint>();
            CreatedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
        }
    }
}
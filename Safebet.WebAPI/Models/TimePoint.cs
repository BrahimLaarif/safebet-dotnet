using System;

namespace Safebet.WebAPI.Models
{
    public class TimePoint
    {
        public int Id { get; set; }
        public string Hash { get; set; }
        public double HomeOdds { get; set; }
        public double DrawOdds { get; set; }
        public double AwayOdds { get; set; }
        public DateTime CreatedDate { get; set; }

        public TimePoint()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
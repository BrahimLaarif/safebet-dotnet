using System;

namespace Safebet.WebAPI.Models
{
    public class TimePoint
    {
        public int Id { get; set; }
        
        public int MatchId { get; set; }

        public string Hash { get; set; }

        public float HomeOdds { get; set; }
        public float DrawOdds { get; set; }
        public float AwayOdds { get; set; }

        public DateTime CreationDate { get; set; }

        public TimePoint()
        {
            CreationDate = DateTime.Now;
        }
    }
}
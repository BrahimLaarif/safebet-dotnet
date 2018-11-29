using System;
using System.Collections.Generic;

namespace Safebet.WebAPI.Models
{
    public class DetailMatch
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime KickoffDate { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public ICollection<TimePoint> TimePoints { get; set; }
        public ICollection<Prediction> Predictions { get; set; }
        public Prediction Prediction { get; set; }
    }
}
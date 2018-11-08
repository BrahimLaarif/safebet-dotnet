using System;
using System.Collections.Generic;
using Safebet.WebAPI.Models;

namespace Safebet.WebAPI.Resources
{
    public class DetailsMatchResource
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public ICollection<TimePoint> TimePoints { get; set; }
        public ICollection<Prediction> Predictions { get; set; }
        public Prediction LastPrediction { get; set; }
    }
}
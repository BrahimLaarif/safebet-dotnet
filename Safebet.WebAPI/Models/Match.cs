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

        public virtual ICollection<TimePoint> TimePoints { get; set; }
        public string LastTimePointHash { get; set; }

        public virtual ICollection<Prediction> Predictions { get; set; }
        public int? LastPredictionId { get; set; }
        public virtual Prediction LastPrediction { get; set; }

        public bool Processed { get; set; }
        
        public string Result { get; set; }

        public DateTime CreationDate { get; set; }

        public Match()
        {
            TimePoints = new Collection<TimePoint>();
            Predictions = new Collection<Prediction>();
            CreationDate = DateTime.Now;
        }
    }
}
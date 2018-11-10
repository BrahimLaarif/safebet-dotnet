using System;
using Safebet.WebAPI.Models;

namespace Safebet.WebAPI.Resources
{
    public class CardMatchResource
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public DateTime CreationDate { get; set; }
        public Prediction LastPrediction { get; set; }
    }
}
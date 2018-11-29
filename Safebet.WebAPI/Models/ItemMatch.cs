using System;

namespace Safebet.WebAPI.Models
{
    public class ItemMatch
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime KickoffDate { get; set; }
        public string Name { get; set; }
        public string Result { get; set; }
        public Prediction Prediction { get; set; }
    }
}
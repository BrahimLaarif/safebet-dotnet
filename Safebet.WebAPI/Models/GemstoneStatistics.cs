using System.Collections.Generic;

namespace Safebet.WebAPI.Models
{
    public class GemstoneStatistics
    {
        public int Count { get; set; }
        public int ErrorsCount { get; set; }
        public float Winrate { get; set; }
        public float CurrentBalance { get; set; }
        public List<float> Bankroll { get; set; }
        public float MaxBankroll { get; set; }
        public float MeanBankroll { get; set; }

        public GemstoneStatistics()
        {
            CurrentBalance = 100.0f;
            Bankroll = new List<float>();
        }
    }
}
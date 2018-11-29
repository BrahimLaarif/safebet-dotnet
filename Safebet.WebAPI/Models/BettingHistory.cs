using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Safebet.WebAPI.Models
{
    public class BettingHistory
    {
        public int Count { get; set; }
        public int ErrorsCount { get; set; }
        public float WinRate { get; set; }
        public float Balance { get; set; }
        public List<float> BalanceHistory { get; set; }
        public ICollection<Bet> Bets { get; set; }

        public BettingHistory()
        {
            var initialBalance = 100.0f;

            Balance = initialBalance;
            BalanceHistory = new List<float>() { initialBalance };
            Bets = new Collection<Bet>();
        }
    }
}
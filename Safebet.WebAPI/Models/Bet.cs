using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Safebet.WebAPI.Models
{
    public class Bet
    {
        public int Count { get; set; }
        public float Odds { get; set; }
        public float Amount { get; set; }
        public float AmountToReturn { get; set; }
        public DateTime BetDate { get; set; }
        public bool Processed { get; set; }
        public int ErrorsCount { get; set; }
        public string Result { get; set; }
        public DateTime CashoutDate { get; set; }
        public ICollection<ItemMatch> Matches { get; set; }

        public Bet()
        {
            Matches = new Collection<ItemMatch>();
        }
    }
}
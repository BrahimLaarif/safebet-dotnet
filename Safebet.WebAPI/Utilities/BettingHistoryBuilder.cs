using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Safebet.WebAPI.Models;

namespace Safebet.WebAPI.Utilities
{
    public class BettingHistoryBuilder
    {
        private readonly IEnumerable<DateGroup> groups;
        private readonly BettingHistory bettingHistory;
        
        public BettingHistoryBuilder(IEnumerable<DateGroup> groups)
        {
            this.groups = groups;
            this.bettingHistory = new BettingHistory();
        }

        public BettingHistory BuildBettingHistory()
        {
            foreach (var group in groups)
            {
                PopulateBettingHistory(group);
            }

            return bettingHistory;
        }

        private void PopulateBettingHistory(DateGroup group)
        {
            foreach (var match in group.Matches)
            {
                if (match.Result != null && match.Prediction != null)
                {
                    var odds = match.Prediction.PredictedResultOdds;
                    var amount = bettingHistory.Balance / 3;
                    var amountToReturn = amount * odds;
                    var betDate = match.KickoffDate;
                    var cashoutDate = match.KickoffDate.AddMinutes(115);

                    ProcessPendingBets(betDate);

                    var bet = new Bet()
                    {
                        Count = 1,
                        Odds = odds,
                        BalanceBeforeBet = bettingHistory.Balance,
                        Amount = amount,
                        AmountToReturn = amountToReturn,
                        BetDate = betDate,
                        CashoutDate = cashoutDate,
                        Matches = new Collection<ItemMatch>() { match }
                    };

                    bettingHistory.Count += 1;
                    bettingHistory.Bets.Add(bet);
                    bettingHistory.Balance -= bet.Amount;
                }
            }

            ProcessPendingBets();
        }

        private void ProcessPendingBets(DateTime? date = null)
        {
            foreach (var bet in bettingHistory.Bets)
            {
                if (!bet.Processed && (!date.HasValue || bet.CashoutDate <= date))
                {
                    var errorsCount = 0;

                    foreach (var match in bet.Matches)
                    {
                        if (match.Result != match.Prediction.PredictedResult)
                        {
                            errorsCount++;
                        }
                    }

                    if (errorsCount == 0)
                    {
                        bet.Result = "won";
                        bettingHistory.Balance += bet.AmountToReturn;
                        bet.BalanceAfterCashout = bettingHistory.Balance;
                        bettingHistory.BalanceHistory.Add(bettingHistory.Balance);
                    }
                    else
                    {
                        bet.Result = "lost";
                        bet.BalanceAfterCashout = bettingHistory.Balance;
                        bettingHistory.ErrorsCount += 1;
                        bettingHistory.BalanceHistory.Add(bettingHistory.Balance);
                    }

                    bet.ErrorsCount = errorsCount;
                    bet.Processed = true;
                }
            }

            ProcessWinRate();
        }

        private void ProcessWinRate()
        {
            if (bettingHistory.Count > 0)
            {
                bettingHistory.WinRate = ((float)bettingHistory.Count - (float)bettingHistory.ErrorsCount) / (float)bettingHistory.Count;
            }
        }

        private float RoundFloat(float value)
        {
            return (float)Math.Round(value, 2);
        }
    }
}
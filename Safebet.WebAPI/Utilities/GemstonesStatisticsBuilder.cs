using System;
using System.Collections.Generic;
using System.Linq;
using Safebet.WebAPI.Models;

namespace Safebet.WebAPI.Utilities
{
    public class GemstonesStatisticsBuilder
    {
        private readonly ICollection<Match> matches;
        public GemstonesStatisticsBuilder(ICollection<Match> matches)
        {
            this.matches = matches;
        }

        private Dictionary<string, GemstoneStatistics> InitializeGemstonesStatistics(List<string> gemstones)
        {
            var statistics = new Dictionary<string, GemstoneStatistics>();

            foreach (var gemstone in gemstones)
            {
                statistics.Add(gemstone, new GemstoneStatistics());
            }

            return statistics;
        }

        public Dictionary<string, GemstoneStatistics> BuildGemstonesStatistics(List<string> gemstones)
        {
            var GemstonesStatistics = InitializeGemstonesStatistics(gemstones);

            foreach (var match in matches)
            {
                foreach (var gemstone in gemstones)
                {
                    if (match.LastPrediction.Gemstone == gemstone)
                    {
                        GemstonesStatistics[gemstone] = PopulateGemstoneStatistics(GemstonesStatistics[gemstone], match);
                    }
                }
            }

            return GemstonesStatistics;
        }

        public GemstoneStatistics BuildGemstoneStatistics(List<string> gemstones)
        {
            var gemstoneStatistics = new GemstoneStatistics();
            
            foreach (var match in matches)
            {
                if (gemstones.Contains(match.LastPrediction.Gemstone))
                {
                    gemstoneStatistics = PopulateGemstoneStatistics(gemstoneStatistics, match);
                }
            }

            return gemstoneStatistics;
        }

        public static GemstoneStatistics PopulateGemstoneStatistics(GemstoneStatistics gemstoneStatistics, Match match)
        {
            gemstoneStatistics.Count += 1;
            gemstoneStatistics.ErrorsCount += IfCorrect(match) ? 0 : 1;
            gemstoneStatistics.Winrate = GetWinrate(gemstoneStatistics);
            gemstoneStatistics.CurrentBalance = GetCurrentBalance(match, gemstoneStatistics.CurrentBalance);
            gemstoneStatistics.Bankroll.Add(gemstoneStatistics.CurrentBalance);
            gemstoneStatistics.MaxBankroll = GetMaxBankroll(gemstoneStatistics.Bankroll);
            gemstoneStatistics.MeanBankroll = GetMeanBankroll(gemstoneStatistics.Bankroll);

            return gemstoneStatistics;
        }

        public static bool IfCorrect(Match match)
        {
            if (match.Result == match.LastPrediction.PredictedResult) 
            {
                return true;
            }
            else {
                return false;
            }
        }

        public static float GetWinrate(GemstoneStatistics gemstoneStatistics)
        {
            if (gemstoneStatistics.Count > 0)
            {
                return (float) Math.Round((1 - ((float) gemstoneStatistics.ErrorsCount / (float) gemstoneStatistics.Count)) * 100, 2);
            }

            return 0;
        }

        public static float GetCurrentBalance(Match match, float currentBalance)
        {
            var amountToBet = currentBalance / 3;

            currentBalance = (float) Math.Round(currentBalance - amountToBet, 2);

            if (IfCorrect(match))
            {
                var amountToReturn = amountToBet * match.LastPrediction.PredictedResultOdds;

                currentBalance = (float) Math.Round(currentBalance + amountToReturn, 2);
            }

            return currentBalance;
        }

        public static float GetMaxBankroll(List<float> bankroll)
        {
            var maxBankroll = 0.0f;

            foreach (var balance in bankroll)
            {
                if (balance > maxBankroll)
                {
                    maxBankroll = balance;
                }
            }

            return maxBankroll;
        }

        public static float GetMeanBankroll(List<float> bankroll)
        {
            return bankroll.Average();
        }
    }
}
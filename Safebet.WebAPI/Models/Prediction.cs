using System;
using System.ComponentModel.DataAnnotations;

namespace Safebet.WebAPI.Models
{
    public class Prediction
    {
        public int Id { get; set; }

        public int MatchId { get; set; }

        public float HomeOdds { get; set; }
        public float DrawOdds { get; set; }
        public float AwayOdds { get; set; }

        [Required]
        public string FavoriteResult { get; set; }

        public float HomeOddsGain { get; set; }
        public float DrawOddsGain { get; set; }
        public float AwayOddsGain { get; set; }

        public float H1 { get; set; }
        public float H2 { get; set; }
        public float H3 { get; set; }
        public float H4 { get; set; }
        public float H5 { get; set; }
        public float D1 { get; set; }
        public float D2 { get; set; }
        public float D3 { get; set; }
        public float D4 { get; set; }
        public float D5 { get; set; }
        public float A1 { get; set; }
        public float A2 { get; set; }
        public float A3 { get; set; }
        public float A4 { get; set; }
        public float A5 { get; set; }

        public float HomeDropIndex { get; set; }
        public float DrawDropIndex { get; set; }
        public float AwayDropIndex { get; set; }

        public float HomeMovementIndex { get; set; }
        public float DrawMovementIndex { get; set; }
        public float AwayMovementIndex { get; set; }

        [Required]
        public string PredictedResult { get; set; }
        public float PredictedHomeProba { get; set; }
        public float PredictedDrawProba { get; set; }
        public float PredictedAwayProba { get; set; }
        public float PredictedResultProba { get; set; }
        public float PredictedResultOdds { get; set; }
        public float PredictedResultOddsGain { get; set; }
        public float PredictedResultDropIndex { get; set; }
        public float PredictedResultMovementIndex { get; set; }

        public int AccuratePrediction { get; set; }
        public int BalancedOdds { get; set; }
        public int HomeAdvantage { get; set; }
        public int PredictedResultProbaIsSafe { get; set; }
        public int PredictedResultOddsIsSafe { get; set; }
        public int PredictedResultGainsAndDropsIsGoingDown { get; set; }
        public int OtherResultsGainsAndDropsIsGoingUp { get; set; }
        public int PredictedResultGraphIsChaotic { get; set; }
        public int PredictedResultGraphIsGoingDown { get; set; }
        public int PredictedResultGraphTailIsGoingDown { get; set; }

        public int PredictedSafetyLevel { get; set; }
        public float PredictedUnsafeProba { get; set; }
        public float PredictedSafeProba { get; set; }
        public float PredictedSafetyLevelProba { get; set; }

        public string Gemstone { get; set; }

        public DateTime CreationDate { get; set; }

        public Prediction()
        {
            CreationDate = DateTime.Now.ToUniversalTime();
        }
    }
}
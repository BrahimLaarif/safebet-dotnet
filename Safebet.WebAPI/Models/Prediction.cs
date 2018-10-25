using System;
using System.ComponentModel.DataAnnotations;

namespace Safebet.WebAPI.Models
{
    public class Prediction
    {
        public int Id { get; set; }

        public double HomeOdds { get; set; }
        public double DrawOdds { get; set; }
        public double AwayOdds { get; set; }

        [Required]
        public string FavoriteResult { get; set; }

        public double HomeOddsGain { get; set; }
        public double DrawOddsGain { get; set; }
        public double AwayOddsGain { get; set; }

        public double H1 { get; set; }
        public double H2 { get; set; }
        public double H3 { get; set; }
        public double H4 { get; set; }
        public double H5 { get; set; }
        public double D1 { get; set; }
        public double D2 { get; set; }
        public double D3 { get; set; }
        public double D4 { get; set; }
        public double D5 { get; set; }
        public double A1 { get; set; }
        public double A2 { get; set; }
        public double A3 { get; set; }
        public double A4 { get; set; }
        public double A5 { get; set; }

        public double HomeDropIndex { get; set; }
        public double DrawDropIndex { get; set; }
        public double AwayDropIndex { get; set; }

        public double HomeMovementIndex { get; set; }
        public double DrawMovementIndex { get; set; }
        public double AwayMovementIndex { get; set; }

        public DateTime CreatedDate { get; set; }

        public Prediction()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
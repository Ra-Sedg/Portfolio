using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunTracker.Models
{
    public class Run
    {
        public const int SecondsInHour = 3600;
        public const int SecondsInMinute = 60;

        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public double Distance { get; set; }
        public string Location { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        [ForeignKey("ApplicationUserForeignKey")]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ShoeForeignKey")]
        public int? ShoeId { get; set; }

        public int TotalSeconds
        {
            get
            {
                return Seconds + (Hours * SecondsInHour) + (Minutes * SecondsInMinute);
            }
        }

        public double PaceDouble
        {
            get
            {
                double TotalMinutes = (double)TotalSeconds / 60;
                
                return TotalMinutes / Distance;
            }
        }

        public string PaceString 
        {
            get
            {
                TimeSpan Pace = TimeSpan.FromSeconds(TotalSeconds / Distance);
                return Pace.ToString(@"hh\:mm\:ss");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunTracker.Models
{
    public class ChartViewModel
    {
        public bool ShowAllRuns { get; set; }
        public int SelectedMonth { get; set; }
        public int SelectedYear { get; set; }
        public DateTime CurrentDate { get; set; }

        public ApplicationUser User { get; set; }
        public List<Run> Runs { get; set; }

        public double GetTotalMileage()
        {
            if (Runs == null)
            {
                return 0.0;
            }
            else
            {
                return Runs.Sum(run => run.Distance);
            }
        }

        public Run GetFastest()
        {
            if (Runs == null)
            {
                return null;
            }
            else
            {
                return Runs.OrderBy(r => r.PaceDouble)
                                 .FirstOrDefault();
            }
        }

        public Run GetFarthest()
        {
            if (Runs == null)
            {
                return null;
            }
            else
            {
                return Runs.OrderByDescending(r => r.Distance)
                           .FirstOrDefault();
            }
        }
    }
}

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
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RunTracker.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool InUse { get; set; }

        [ForeignKey("ApplicationUserForeignKey")]
        public string ApplicationUserId { get; set; }

        public virtual List<Run> Runs { get; set; }

        public double Mileage
        {
            get
            {
                if (Runs == null)
                {
                    return 0.0;
                }
                else
                {
                    return Runs.Sum(x => x.Distance);
                }
            }
        }
    }
}

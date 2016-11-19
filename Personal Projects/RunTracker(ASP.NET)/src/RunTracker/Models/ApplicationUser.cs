using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RunTracker.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public virtual List<Run> Runs { get; set; }
        public virtual List<Shoe> Shoes { get; set; }

        public string GetName()
        {
            if( FirstName == null || LastName == null)
            {
                return "New User"; 
            }
            else {
                return FirstName + " " + LastName;
            }
        }

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

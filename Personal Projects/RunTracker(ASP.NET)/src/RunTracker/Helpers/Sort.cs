using RunTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace RunTracker.Helpers
{
    abstract class Sort
    {
        // Sort User Runs for Run/Index
        public static List<Run> SortRuns(List<Run> runs, string sortOrder)
        {
            switch (sortOrder)
            {
                case "Location_Desc":
                    runs = runs.OrderByDescending(r => r.Location).ToList();
                    break;
                case "Location_Asc":
                    runs = runs.OrderBy(r => r.Location).ToList();
                    break;
                case "Distance_Desc":
                    runs = runs.OrderByDescending(r => r.Distance).ToList();
                    break;
                case "Distance_Asc":
                    runs = runs.OrderBy(r => r.Distance).ToList();
                    break;
                case "Pace_Desc":
                    runs = runs.OrderByDescending(r => ((double)r.TotalSeconds / r.Distance)).ToList();
                    break;
                case "Pace_Asc":
                    runs = runs.OrderBy(r => ((double)r.TotalSeconds / r.Distance)).ToList();
                    break;
                case "Shoe_Desc":
                    runs = runs.OrderByDescending(r => r.ShoeId).ToList();
                    break;
                case "Shoe_Asc":
                    runs = runs.OrderBy(r => r.ShoeId).ToList();
                    break;
                case "Date_Asc":
                    runs = runs.OrderBy(r => r.Date).ToList();
                    break;
                case "Date_Desc":
                    runs = runs.OrderByDescending(s => s.Date).ToList();
                    break;
                default:
                    runs = runs.OrderByDescending(s => s.Date).ToList();
                    break;
            }
            return runs;
        }

        // Sort User Shoes for /Shoe/Index
        public static List<Shoe> SortShoes(List<Shoe> shoes, string sortOrder)
        {
            switch (sortOrder)
            {
                case "Name_Desc":
                    shoes = shoes.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Name_Asc":
                    shoes = shoes.OrderBy(s => s.Name).ToList();
                    break;
                case "Mileage_Desc":
                    shoes = shoes.OrderByDescending(s => s.Mileage).ToList();
                    break;
                case "Mileage_Asc":
                    shoes = shoes.OrderBy(s => s.Mileage).ToList();
                    break;
                default:
                    shoes = shoes.OrderBy(s => s.Name).ToList();
                    break;
            }
            return shoes;
        }
    }
}

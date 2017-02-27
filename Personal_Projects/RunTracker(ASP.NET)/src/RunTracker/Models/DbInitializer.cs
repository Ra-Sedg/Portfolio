using Microsoft.AspNetCore.Identity;
using RunTracker.Data;
using System;
using System.Linq;

namespace RunTracker.Models
{
    public class DbInitializer
    {
        private static UserManager<ApplicationUser> _manager;
        private static ApplicationDbContext _context;

        // Seeds database with a test user if no users are found in the database.
        public static void Initizlize(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {
            _context = context;
            _manager = manager;

            _context.Database.EnsureCreated();

            // Look for seed data
            if (_context.Users.Any())
            {
                return;     // Db has been seeded already
            }

            // Add test user
            var testUser = new ApplicationUser { Email = "test@gmail.com", UserName = "test@gmail.com", FirstName = "Robert", LastName = "Sedgwick",
                                                 Age = 31, PhoneNumber = "705-252-0096"};
            _manager.CreateAsync(testUser, "Test1234!");

            // Add shoes
            var Shoebox = new Shoe[]
            {
                new Shoe {Name = "Asics"      , ApplicationUserId = testUser.Id, InUse = true },    // Id: 1
                new Shoe {Name = "Nike"       , ApplicationUserId = testUser.Id, InUse = true },    // Id: 2
                new Shoe {Name = "Brooks"     , ApplicationUserId = testUser.Id, InUse = true },    // Id: 3
                new Shoe {Name = "New Balance", ApplicationUserId = testUser.Id, InUse = true },    // Id: 4
                new Shoe {Name = "Old Asics"  , ApplicationUserId = testUser.Id, InUse = false },   // Id: 5
                new Shoe {Name = "Old Nike"   , ApplicationUserId = testUser.Id,  InUse = false }   // Id: 6
            };

            foreach (Shoe s in Shoebox)
            {
                _context.Shoe.Add(s);
            }

            _context.SaveChanges();

            // Add runs
            var RunLog = new Run[]
            {
                new Run {Date = DateTime.Parse("8-2-16"), Distance = 4.00, Hours = 0, Minutes = 46, Seconds = 47,
                    Location = "Street", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-4-16"), Distance = 4.00, Hours = 0, Minutes = 47, Seconds = 29,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-5-16"), Distance = 3.02, Hours = 0, Minutes = 34, Seconds = 48,
                    Location = "Treadmill", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-6-16"), Distance = 3.13, Hours = 0, Minutes = 34, Seconds = 18,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-9-16"), Distance = 4.40, Hours = 0, Minutes = 46, Seconds = 50,
                    Location = "Street", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-11-16"), Distance = 4.00, Hours = 0, Minutes = 47, Seconds = 17,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-12-16"), Distance = 4.01, Hours = 0, Minutes = 51, Seconds = 56,
                    Location = "Track", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-13-16"), Distance = 4.00, Hours = 0, Minutes = 44, Seconds = 30,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-16-16"), Distance = 6.00, Hours = 1, Minutes = 8, Seconds = 54,
                    Location = "Treadmill", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-18-16"), Distance = 4.00, Hours = 0, Minutes = 42, Seconds = 46,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-20-16"), Distance = 5.00, Hours = 0, Minutes = 54, Seconds = 20,
                    Location = "Street", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-23-16"), Distance = 6.23, Hours = 1, Minutes = 5, Seconds = 23,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-25-16"), Distance = 4.00, Hours = 0, Minutes = 42, Seconds = 19,
                    Location = "Track", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-27-16"), Distance = 3.99, Hours = 0, Minutes = 48, Seconds = 0,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("8-30-16"), Distance = 6.22, Hours = 1, Minutes = 7, Seconds = 11,
                    Location = "Street", ShoeId = 5, ApplicationUserId = testUser.Id },

                new Run {Date = DateTime.Parse("9-1-16"), Distance = 6.21, Hours = 1, Minutes = 6, Seconds = 11,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-3-16"), Distance = 6.21, Hours = 1, Minutes = 8, Seconds = 23,
                    Location = "Street", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-6-16"), Distance = 6.22, Hours = 1, Minutes = 3, Seconds = 58,
                    Location = "Track", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-8-16"), Distance = 6.22, Hours = 1, Minutes = 5, Seconds = 8,
                    Location = "Street", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-10-16"), Distance = 6.21, Hours = 1, Minutes = 13, Seconds = 27,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-13-16"), Distance = 7.00, Hours = 1, Minutes = 14, Seconds = 42,
                    Location = "Treadmill", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-15-16"), Distance = 6.22, Hours = 1, Minutes = 6, Seconds = 23,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-17-16"), Distance = 7.02, Hours = 1, Minutes = 12, Seconds = 14,
                    Location = "Track", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-20-16"), Distance = 9, Hours = 1, Minutes = 28, Seconds = 23,
                    Location = "Street", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-6-16"), Distance = 6.22, Hours = 1, Minutes = 3, Seconds = 58,
                    Location = "Street", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-22-16"), Distance = 6.23, Hours = 1, Minutes = 2, Seconds = 5,
                    Location = "Treadmill", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-23-16"), Distance = 1.48, Hours = 0, Minutes = 19, Seconds = 03,
                    Location = "Street", ShoeId = 5, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-24-16"), Distance = 6.23, Hours = 1, Minutes = 9, Seconds = 14,
                    Location = "Track", ShoeId = 6, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-27-16"), Distance = 8.06, Hours = 1, Minutes = 21, Seconds = 14,
                    Location = "Track", ShoeId = 2, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-28-16"), Distance = 1.52, Hours = 0, Minutes = 18, Seconds = 02,
                    Location = "Street", ShoeId = 3, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-29-16"), Distance = 6.22, Hours = 1, Minutes = 0, Seconds = 45,
                    Location = "Street", ShoeId = 4, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("9-30-16"), Distance = 1.51, Hours = 0, Minutes = 18, Seconds = 42,
                    Location = "Treadmill", ShoeId = 2, ApplicationUserId = testUser.Id },

                new Run {Date = DateTime.Parse("10-1-16"), Distance = 8.03, Hours = 1, Minutes = 25, Seconds = 33,
                    Location = "Street", ShoeId = 2, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-5-16"), Distance = 10.03, Hours = 1, Minutes = 47, Seconds = 02,
                    Location = "Street", ShoeId = 3, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-7-16"), Distance = 6.22, Hours = 1, Minutes = 9, Seconds = 56,
                    Location = "Tack", ShoeId = 4, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-9-16"), Distance = 6.24, Hours = 1, Minutes = 3, Seconds = 53,
                    Location = "Street", ShoeId = 2, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-10-16"), Distance = 2.71, Hours = 0, Minutes = 35, Seconds = 43,
                    Location = "Tack", ShoeId = 3, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-11-16"), Distance = 10.07, Hours = 1, Minutes = 49, Seconds = 56,
                    Location = "Street", ShoeId = 4, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-12-16"), Distance = 1.50, Hours = 0, Minutes = 19, Seconds = 52,
                    Location = "Treadmill", ShoeId = 2, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-13-16"), Distance = 6.22, Hours = 1, Minutes = 03, Seconds = 32,
                    Location = "Street", ShoeId = 3, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-15-16"), Distance = 10.00, Hours = 1, Minutes = 46, Seconds = 27,
                    Location = "Track", ShoeId = 4, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-18-16"), Distance = 10.00, Hours = 1, Minutes = 49, Seconds = 56,
                    Location = "Street", ShoeId = 2, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-20-16"), Distance = 7.50, Hours = 1, Minutes = 19, Seconds = 56,
                    Location = "Treadmill", ShoeId = 2, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-25-16"), Distance = 13.12, Hours = 2, Minutes = 19, Seconds = 56,
                    Location = "Street", ShoeId = 1, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-29-16"), Distance = 6.99, Hours = 1, Minutes = 19, Seconds = 23,
                    Location = "Street", ShoeId = 2, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("10-1-16"), Distance = 8.03, Hours = 1, Minutes = 25, Seconds = 33,
                    Location = "Street", ShoeId = 3, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("11-2-16"), Distance = 3.76, Hours = 0, Minutes = 41, Seconds = 02,
                    Location = "Street", ShoeId = 4, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("11-3-16"), Distance = 6.59, Hours = 1, Minutes = 59, Seconds = 11,
                    Location = "Street", ShoeId = 1, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("11-5-16"), Distance = 10.00, Hours = 1, Minutes = 45, Seconds = 26,
                    Location = "Street", ShoeId = 2, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("11-8-16"), Distance = 4.02, Hours = 0, Minutes = 37, Seconds = 11,
                    Location = "Street", ShoeId = 3, ApplicationUserId = testUser.Id },
                new Run {Date = DateTime.Parse("11-10-16"), Distance = 2.03, Hours = 0, Minutes = 20, Seconds = 08,
                    Location = "Street", ShoeId = 4, ApplicationUserId = testUser.Id }
            };

            foreach (Run r in RunLog)
            {
                _context.Run.Add(r);
            }

            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfProgrammer
{
    class Program
    {
        static void Main(string[] args)
        {

            int inYear = 1916;
            int day, month, year;
            DateTime date = new DateTime(inYear, 1, 1);
            date = date.AddDays(255);
            Calendar julian = new JulianCalendar();
            Calendar gregorian = new GregorianCalendar();

            if (inYear < 1918)
            {
                day = julian.GetDayOfMonth(date);
                month = julian.GetMonth(date);
                year = julian.GetYear(date);
                date = new DateTime(year, month, day);      
                
            }
            else
            {
                if (inYear == 1918)
                {
                    date = date.AddDays(-12);
                }
                day = gregorian.GetDayOfMonth(date);
                month = gregorian.GetMonth(date);
                year = gregorian.GetYear(date);
                date = new DateTime(year, month, day);
            }

            Console.WriteLine(date.ToString("dd.MM.yyyy"));

            Console.ReadKey();
        }
      
    }

}

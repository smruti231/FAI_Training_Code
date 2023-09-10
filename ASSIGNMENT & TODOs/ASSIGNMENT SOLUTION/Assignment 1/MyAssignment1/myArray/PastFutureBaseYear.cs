using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1.myArray
    {
    class PastFutureBaseYear
        {
        static void Main(string[] args)
            {
            DateTime baseDate = new DateTime(2016, 2, 29);

            Console.WriteLine("Base Date: " + baseDate.ToShortDateString());
            for (int years = 1; years <= 15; years++)
                {
                DateTime pastDate = baseDate.AddYears(-years);
                DateTime futureDate = baseDate.AddYears(years);

                Console.WriteLine($"{years} year(s) ago: {pastDate.ToShortDateString()}");
                Console.WriteLine($"{years} year(s) from now: {futureDate.ToShortDateString()}");

                }
            }
        }
    }

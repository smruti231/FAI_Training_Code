using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    class Q8PrintCalender1
        {
        static void Main(string[] args)
            {
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter month (1-12): ");
            int month = int.Parse(Console.ReadLine());

            if (month < 1 || month > 12)
                {
                Console.WriteLine("Invalid month input. Month should be between 1 and 12.");
                }
            else
                {
                printCalendar(month, year);
                }
            }

        public static void printCalendar(int month, int year)
            {
            DateTime date = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            Console.WriteLine($"Calendar for {date.ToString("MMMM yyyy")}");

            Console.WriteLine(" Sun Mon Tue Wed Thu Fri Sat");

            int dayOfWeek = (int)date.DayOfWeek;
            for (int i = 0; i < dayOfWeek; i++)
                {
                Console.Write("    ");
                }

            for (int day = 1; day <= daysInMonth; day++)
                {
                Console.Write($"{day,4}");

                if (date.DayOfWeek == DayOfWeek.Saturday)
                    {
                    Console.WriteLine();
                    }

                date = date.AddDays(1);
                }

            Console.WriteLine();
            }
        }
    }

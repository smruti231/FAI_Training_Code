using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    class Q8PrintCalender2
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
            Console.WriteLine($"Calendar for {GetMonthName(month)} {year}");

            Console.WriteLine(" Sun Mon Tue Wed Thu Fri Sat");

            int dayOfWeek = GetDayOfWeek(year, month, 1);

            int daysInMonth = GetDaysInMonth(year, month);

            for (int i = 0; i < dayOfWeek; i++)
                {
                Console.Write("    ");
                }

            for (int day = 1; day <= daysInMonth; day++)
                {
                Console.Write($"{day,4}");

                if (dayOfWeek == 7)
                    {
                    Console.WriteLine();
                    dayOfWeek = 0;
                    }
                else
                    {
                    dayOfWeek++;
                    }
                }

            Console.WriteLine();
            }

        public static string GetMonthName(int month)
            {
            string[] monthNames = {
                "January", "February", "March", "April",
                "May", "June", "July", "August",
                "September", "October", "November", "December"
            };

            return monthNames[month - 1];
            }

        public static int GetDayOfWeek(int year, int month, int day)
            {
            // Zeller's Congruence algorithm
            if (month < 3)
                {
                month += 12;
                year--;
                }

            int h = (day + 2 * month + 3 * (month + 1) / 5 + year + year / 4 - year / 100 + year / 400) % 7;

            return h;
            }

        public static int GetDaysInMonth(int year, int month)
            {
            int[] daysInMonth = {
                31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
            };

            if (IsLeapYear(year) && month == 2)
                {
                return 29;
                }

            return daysInMonth[month - 1];
            }

        public static bool IsLeapYear(int year)
            {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            }
        }
    }

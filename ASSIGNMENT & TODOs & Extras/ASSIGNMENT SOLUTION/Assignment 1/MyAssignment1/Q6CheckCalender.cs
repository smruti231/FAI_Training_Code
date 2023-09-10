using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    class Q6CheckCalender
        {
        class Program
            {
            static void Main(string[] args)
                {
                while (true)
                    {
                    Console.Write("Enter year: ");
                    int year = int.Parse(Console.ReadLine());

                    Console.Write("Enter month: ");
                    int month = int.Parse(Console.ReadLine());

                    Console.Write("Enter day: ");
                    int day = int.Parse(Console.ReadLine());

                    bool isValid = isValidDate(year, month, day);

                    if (isValid)
                        {
                        Console.WriteLine("Valid date!");
                        }
                    else
                        {
                        Console.WriteLine("Invalid date.");
                        }

                    Console.Write("Do you want to check another date? (y/n): ");
                    string response = Console.ReadLine();

                    if (response.ToLower() != "y")
                        {
                        break;
                        }
                    }
                }

            static bool isValidDate(int year, int month, int day)
                {
                if (year < 1 || month < 1 || month > 12 || day < 1)
                    {
                    return false;
                    }

                if (month == 2)
                    {
                    if (IsLeapYear(year))
                        {
                        return day <= 29;
                        }
                    else
                        {
                        return day <= 28;
                        }
                    }
                else if (month == 4 || month == 6 || month == 9 || month == 11)
                    {
                    return day <= 30;
                    }
                else
                    {
                    return day <= 31;
                    }
                }

            static bool IsLeapYear(int year)
                {
                return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
                }
            }
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    class Q10DigitReader
        {
        static void Main(string[] args)
            {
            while (true)
                {
                Console.Write("Enter a number between 1 and 99,99,99,999: ");
                int num = int.Parse(Console.ReadLine());

                if (num >= 1 && num <= 999999999)
                    {
                    string words = inWords(num);
                    Console.WriteLine($"In words: {words}");
                    }
                else
                    {
                    Console.WriteLine("Invalid input. Please enter a number within the specified range.");
                    }

                Console.Write("Do you want to convert another number? (y/n): ");
                string response = Console.ReadLine();

                if (response.ToLower() != "y")
                    {
                    break;
                    }
                }
            }

        public static string inWords(int num)
            {
            string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            if (num == 0)
                {
                return "zero";
                }

            if (num < 10)
                {
                return units[num];
                }

            if (num < 20)
                {
                return teens[num - 10];
                }

            if (num < 100)
                {
                return $"{tens[num / 10]} {units[num % 10]}".Trim();
                }

            if (num < 1000)
                {
                return $"{units[num / 100]} hundred {inWords(num % 100)}".Trim();
                }

            if (num < 100000)
                {
                return $"{inWords(num / 1000)} thousand {inWords(num % 1000)}".Trim();
                }

            if (num < 10000000)
                {
                return $"{inWords(num / 100000)} lakh {inWords(num % 100000)}".Trim();
                }

            return $"{inWords(num / 10000000)} crore {inWords(num % 10000000)}".Trim();
            }
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1.myArray
    {
    class countChar
        {
        static void Main(string[] args)
            {
            string input = Utilities.GetString("Enter a string: ");
            int alphabetCount = 0;
            int digitCount = 0;
            int specialCharCount = 0;

            foreach (char ch in input)
                {
                if (char.IsLetter(ch))
                    {
                    alphabetCount++;
                    }
                else if (char.IsDigit(ch))
                    {
                    digitCount++;
                    }
                else
                    {
                    specialCharCount++;
                    }
                }

            Console.WriteLine($"Total Alphabets: {alphabetCount}");
            Console.WriteLine($"Total Digits: {digitCount}");
            Console.WriteLine($"Total Special Characters: {specialCharCount}");

            }
        }
    }

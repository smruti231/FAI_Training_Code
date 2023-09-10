using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    class Q11InterestCalc
        {
        static void Main(string[] args)
            {
            Console.Write("Enter the Principal Amount: ");
            double principal = double.Parse(Console.ReadLine());

            Console.Write("Enter the Rate of Interest (as a decimal): ");
            double rate = double.Parse(Console.ReadLine());

            Console.Write("Enter the Term (in years): ");
            int term = int.Parse(Console.ReadLine());

            double interestAmount = CalculateInterest(principal, rate, term);

            Console.WriteLine($"Principal Amount: ${principal}");
            Console.WriteLine($"Rate of Interest: {rate * 100}%");
            Console.WriteLine($"Term: {term} years");
            Console.WriteLine($"Interest Amount: ${interestAmount}");
            }

        static double CalculateInterest(double principal, double rate, int term)
            {
            double interest = principal * rate * term;
            return interest;
            }
        }
    }

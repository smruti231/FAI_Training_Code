using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    class Q7CheckPrime
        {
        static void Main(string[] args)
            {
            while (true)
                {
                Console.Write("Enter a number: ");
                int num = int.Parse(Console.ReadLine());

                bool isPrime = isPrimeNumber(num);

                if (isPrime)
                    {
                    Console.WriteLine($"{num} is a prime number!");
                    }
                else
                    {
                    Console.WriteLine($"{num} is not a prime number.");
                    }

                Console.Write("Do you want to check another number? (y/n): ");
                string response = Console.ReadLine();

                if (response.ToLower() != "y")
                    {
                    break;
                    }
                }
            }

        static bool isPrimeNumber(int num)
            {
            if (num <= 1)
                {
                return false;
                }

            if (num <= 3)
                {
                return true;
                }

            if (num % 2 == 0 || num % 3 == 0)
                {
                return false;
                }

            for (int i = 5; i * i <= num; i = i + 6)
                {
                if (num % i == 0 || num % (i + 2) == 0)
                    {
                    return false;
                    }
                }

            return true;
            }
        }
    }

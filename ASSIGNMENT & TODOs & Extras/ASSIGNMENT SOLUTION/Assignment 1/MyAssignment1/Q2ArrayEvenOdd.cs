using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
{
    class Q2ArrayEvenOdd
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements in array: ");
            int size = int.Parse(Console.ReadLine());

            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            DisplayOddEVen(numbers);
        }

        static void DisplayOddEVen(int[] numbers)
        {
            Console.WriteLine("Odd Numbers: ");
            foreach (int num in numbers)
            {
                if (num % 2 != 0)
                {
                    Console.WriteLine(num);
                }
            }

            Console.WriteLine("Even Numbers: ");
            foreach (int num in numbers)
            {
                if (num % 2 == 0)
                {
                    Console.WriteLine(num);
                }
            }
        }
    }
}

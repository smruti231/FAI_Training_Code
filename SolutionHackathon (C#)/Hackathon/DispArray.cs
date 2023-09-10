using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
    {
    class DispArray
        {
        static void Main(string[] args)
            {
            int size = Utilities.GetInteger("Enter the size of Array: ");
            int[] numbers = new int[size];
            
            for (int i = 0; i < numbers.Length; i++)
                {
                Console.WriteLine($"Enter number: {i+1}");
                if (int.TryParse(Console.ReadLine(), out int inputNumbers))
                    {
                    numbers[i] = inputNumbers;
                    }
                else
                    {
                    Console.WriteLine("Inavlid Input");
                    i--;
                    }
                }
                Console.WriteLine("Contents of the Array: ");

                foreach(int j in numbers)
                    {
                    Console.WriteLine(j);
                    }
                }
            }
        }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1.myArray
    {
    class SumRow
        {
        static void Main(string[] args)
            {
            int rows = Utilities.GetInteger("Enter the number of rows: ");
            int columns = Utilities.GetInteger("Enter the number of columns: ");

            int[,] matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
                {
                for (int j = 0; j < columns; j++)
                    {
                    matrix[i, j] = Utilities.GetInteger($"Enter element at position [{i},{j}]: ");
                    }

                }

            Console.WriteLine("Matrix with sum of rows as a new column:");
            for (int i = 0; i < rows; i++)
                {
                int rowSum = 0;
                for (int j = 0; j < columns; j++)
                    {
                    Console.Write($"{matrix[i, j]}\t");
                    rowSum += matrix[i, j];
                    }
                Console.WriteLine($"| Sum: {rowSum}");

                }
            }
        }
    }

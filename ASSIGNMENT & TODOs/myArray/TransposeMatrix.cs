using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1.myArray
    {
    class TransposeMatrix
        {
        static void Main(string[] args)
            {
            int rows = Utilities.GetInteger("Enter the number of rows: ");
            int columns = Utilities.GetInteger("Enter the number of columns: ");

            int[,] array = new int[rows, columns];
            for (int i = 0; i < rows; i++)
                {
                for (int j = 0; j < columns; j++)
                    {
                    array[i, j] = Utilities.GetInteger($"Enter element at position [{i},{j}]: ");
                    }

                }
            Console.WriteLine("Original Array:");
            DisplayArray(array, rows, columns);

            Console.WriteLine("Transpose Matrix:");
            DisplayTranspose(array, rows, columns);

            }

        static void DisplayTranspose(int[,] array, int rows, int columns)
            {
            for (int j = 0; j < columns; j++)
                {
                for (int i = 0; i < rows; i++)
                    {
                    Console.Write($"{array[i, j]} ");
                    }
                Console.WriteLine();
                }
            }

        static void DisplayArray(int[,] array, int rows, int columns)
            {
            for (int i = 0; i < rows; i++)
                {
                for (int j = 0; j < columns; j++)
                    {
                    Console.Write($"{array[i, j]} ");
                    }
                Console.WriteLine();
                }
            }
        }

    }
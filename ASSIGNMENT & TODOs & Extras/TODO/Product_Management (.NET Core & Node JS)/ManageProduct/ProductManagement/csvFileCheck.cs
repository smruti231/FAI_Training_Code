using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement
    {
   class csvFileCheck
        {
        const string fileName = @"C:\Users\sranjanpolai\source\repos\ADVANCED PROGRAMMING\DotNETCore\ManageProduct\ProductManagement\Models\Product.csv";
        static void Main(string[] args)
            {
            var i = 1;
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
                {
                string[] words = line.Split(',');
                if (words.Length != 4)
                    {
                    Console.WriteLine(i);
                    }
                i++;
                }
            }
        }
    }

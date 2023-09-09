using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
    {
    class Smruti
        {
        public static void Example()
            {
            Console.WriteLine("Inside Class Example Function");
            }
        class Program
            {
            static void Main(string[] args)
                {
                Console.WriteLine("Calling class example function from Smruti Class");
                Smruti.Example();
                }
            }
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
    {
    class Temp
        {
        static void Main(string[] args)
            {
            const string input = "the quick and brown box jups over the lazy dog";
            string encodeString = EncodeString(input);
            Console.WriteLine("Encoded String: " + encodeString);
            }

        static string EncodeString(string input)
            {
            Console.WriteLine("Enter the word: ");
            string test = Console.ReadLine().ToLower();

            string encoded = "";
            string[] words = input.ToLower().Split(' ');

            if (test == null)
                Console.WriteLine("Throws exception of type NullReferenceException");
            if (test == " ")
                Console.WriteLine("Input String can not be empty");

            

            foreach (char temp in test.ToLower())
                {
                if (char.IsWhiteSpace(temp))
                    {
                    encoded += "-";
                    }
                else
                    {
                    for(int ind=0; ind < words.Length; ind++)
                        {
                        int senIndex = words[ind].IndexOf(temp);
                        if(senIndex != -1)
                            {
                            
                            
                            }
                        }
                    }
                
                }
            return null;
            }
        }
    }

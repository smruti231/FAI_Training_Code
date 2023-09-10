using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
    {
    class Q9RevByWords
        {
        class Program
            {
            static void Main(string[] args)
                {
                while (true)
                    {
                    Console.Write("Enter a sentence: ");
                    string sentence = Console.ReadLine();

                    string reversed = reverseByWords(sentence);
                    Console.WriteLine("Reversed sentence: " + reversed);

                    Console.Write("Do you want to reverse another sentence? (y/n): ");
                    string response = Console.ReadLine();

                    if (response.ToLower() != "y")
                        {
                        break;
                        }
                    }
                }

            public static string reverseByWords(string sentence)
                {
                string[] words = sentence.Split(' ');
                Array.Reverse(words);
                return string.Join(" ", words);
                }
            }
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
    {
    class Program
        {
        static void Main(string[] args)
            {
            //Console.WriteLine("Enter the sentence: ");
            //string input = Console.ReadLine();
            string input = "the quick and brown fox jumps over the lazy dog";
            string encodeString = EncodeString(input);
            Console.WriteLine("Encoded String: " + encodeString);
            }

        static string EncodeString(string input)
            {
            try
                {
                Console.WriteLine("Enter the word: ");
                string test = Console.ReadLine().ToLower() ;

                if (string.IsNullOrWhiteSpace(test))
                    {
                    throw new ArgumentException("Input string can't be empty");
                    }

                StringBuilder encoded = new StringBuilder();

                string[] words = input.ToLower().Split(' ');

                foreach (char temp in test.ToLower())
                    {
                    if(char.IsWhiteSpace(temp))
                        {
                        encoded.Append("-");
                        }
                    else
                        {
                        for (int index = 0; index < words.Length; index++)
                            {
                            int letterIndex = words[index].IndexOf(temp);
                            if (letterIndex != -1)
                                {
                                encoded.Append(index).Append(letterIndex).Append(",");
                                break;
                                }
                    
                            }
                        }
                    }
                if (encoded.Length > 0)
                    {
                    encoded.Length--;
                    }
                return encoded.ToString();
                }
            catch (NullReferenceException)
                {
                Console.WriteLine("Throws exception of type NullReferenceException");
                }
            catch (ArgumentException ex)
                {
                Console.WriteLine(ex.Message);
                }
            return null;
            }
                
            }
        }
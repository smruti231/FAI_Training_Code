using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1.myArray
    {
    class charConversion
        {
        static void Main(string[] args)
            {
            string input = Utilities.GetString("Enter the sentence: ");
            string result = ConvertCase(input);

            Console.WriteLine("Sentence After Conversion: " + result);
            }

        private static string ConvertCase(string input)
            {
            char[] charArray = input.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
                {
                if (char.IsLower(charArray[i]))
                    {
                    charArray[i] = char.ToUpper(charArray[i]);
                    }
                else if (char.IsUpper(charArray[i]))
                    {
                    charArray[i] = char.ToLower(charArray[i]);
                    }
                }

            return new string(charArray);

            }
        }
    }

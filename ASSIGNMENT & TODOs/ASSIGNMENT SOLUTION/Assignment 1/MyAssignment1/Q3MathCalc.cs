using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1
{
    class Q3MathCalc
    {
        static void Main(string[] args)
        {
            bool continueCalculating = true;
            while (continueCalculating)
            {
                Console.WriteLine("Enter the First number: ");
                double num1 = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter the second number: ");
                double num2 = double.Parse(Console.ReadLine());

                Console.Write("Enter the operation (+, -, *, /, %): ");
                char operation = char.Parse(Console.ReadLine());

                double result = 0.0;

                switch (operation)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                            result = num1 / num2;
                        else
                        {
                            Console.WriteLine("can't divide by zero");
                            continue;
                        }
                        break;
                    case '%':
                        result = num1 % num2;
                        break;
                    default:
                        Console.WriteLine("Invalid Operation");
                        continue;
                }

                Console.WriteLine($"Result: {result}");

                Console.Write("Do you want to perform another calculation? (y/n): ");
                char response = char.Parse(Console.ReadLine());

                if (response != 'y' && response != 'Y')
                {
                    continueCalculating = false;
                }

            }
        }
    }
}

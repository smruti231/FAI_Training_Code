using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssignment1.myArray
{
    class Q4DynamicArray
    {
        static void Main(string[] args)
            {
            int size = Utilities.GetInteger("Enter the Array size: ");
            string datatype = Utilities.GetString("Enter the data type(CTS) for the array: ");
            Type type = Type.GetType(datatype);
            if (type == null)
                {
                Console.WriteLine("Invaerlid datatype, can not create anyway");
                }
            Array array = Array.CreateInstance(type, size);
            for (int i = 0; i < size; i++)
                {
                Console.WriteLine($"Enter the value for the array at the index {i} of the datatype {type.Name}");
                var value = Convert.ChangeType(Console.ReadLine(), type);
                array.SetValue(value, i);
                }
            Console.WriteLine("All the values are set!!!");
            foreach (var item in array)
                Console.WriteLine(item);
            }
        }
    }
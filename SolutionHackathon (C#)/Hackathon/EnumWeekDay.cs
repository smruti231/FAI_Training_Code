using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon
    {
        public enum WeekDays
            {Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday}

        public class EnumExamp
            {
            public static void SelectDay()
                {
                Console.WriteLine("Select a day of the week:");
                foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
                    {
                    Console.WriteLine($"{(int)day}: {day}");
                    }
                int input;
                if (int.TryParse(Console.ReadLine(), out input) && Enum.IsDefined(typeof(WeekDays), input))
                    {
                    WeekDays selectedDay = (WeekDays)input;
                    Console.WriteLine($"Selected day: {selectedDay}");
                    }
                else
                    {
                    Console.WriteLine("Invalid input or value.");
                    }
                }
                    
             }

    class EnumWeekDay
        {
        static void Main(string[] args)
            {
            EnumExamp.SelectDay();
            }
        }
    }
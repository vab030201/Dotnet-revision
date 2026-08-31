
using System;

namespace EnumDemo
{
    enum Weekday
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1️⃣ Loop through all enum values
            Console.WriteLine("All Weekdays:");
            foreach (Weekday day in Enum.GetValues(typeof(Weekday)))
            {
                Console.WriteLine($"{(int)day} = {day}");
            }

            Console.WriteLine();

            // 2️⃣ Pick today's day
            Weekday today = Weekday.Wednesday;

            // 3️⃣ Switch statement for logic
            switch (today)
            {
                case Weekday.Monday:
                    Console.WriteLine("Start of the week! कामाला लागा.");
                    break;

                case Weekday.Friday:
                    Console.WriteLine("Weekend जवळ आलंय! थोडं रिलॅक्स करा.");
                    break;

                case Weekday.Saturday:
                case Weekday.Sunday:
                    Console.WriteLine("Holiday! आराम करा.");
                    break;

                default:
                    Console.WriteLine("Regular working day.");
                    break;
            }
        }
    }
}

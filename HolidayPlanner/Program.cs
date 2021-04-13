using System;

namespace HolidayPlanner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Input start date: ");
            var start = Console.ReadLine();

            Console.WriteLine("Input end date: ");
            var end = Console.ReadLine();

            var result = App.Run(start, end);

            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}

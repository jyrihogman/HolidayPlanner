using System;

namespace HolidayPlanner
{
    public static class App
    {
        public static void Run(string start, string end)
        {
            var (result, holidayCount) = HolidayPlanner.ValidateHoliday(start, end);

            switch (result)
            {
                case ValidationResult.Ok:
                    Console.WriteLine($"Holidays is valid, you consumed {holidayCount} days");
                    break;
                case ValidationResult.TooManyDays:
                    Console.WriteLine($"Holidays is NOT valid, you consumed too many days! ({holidayCount})");
                    break;
                case ValidationResult.InvalidRange:
                    Console.WriteLine("Dates are not in a chronological order");
                    break;
                case ValidationResult.InvalidPeriod:
                    Console.WriteLine("Dates are not in the same holiday period");
                    break;
            }
        }
    }
}

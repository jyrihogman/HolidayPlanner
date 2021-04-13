using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayPlanner
{
    public static class App
    {
        public static string Run(string start, string end)
        {
            var (isValid, count) = HolidayPlanner.IsHolidayValid(start, end);

            if (isValid)
            {
                return $"Holidays is valid, you consumed {count} days";
            }

            return $"Holidays is NOT valid, you consumed too many days! ({count})";

        }
    }
}

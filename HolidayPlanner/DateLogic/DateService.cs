using System;

namespace HolidayPlanner.DateLogic
{
    public static class DateService
    {

        public static DateTime GetDate(string input)
        {
            var isDate = DateTime.TryParse(input, out var date);

            if (!isDate)
            {
                throw new Exception("Input wasn't a valid date");
            }

            return date;
        }

    }
}

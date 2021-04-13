using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HolidayPlanner.DateLogic
{

    static class Country
    {
        public const string Finland = "Finland";

        public static IReadOnlyCollection<string> SupportedCountries = new [] { Finland };
    }

    public static class HolidayPlannerService
    {

        private const int MaxDayCount = 50;

        public static IReadOnlyCollection<DateTime> GetConsumedHolidays(
            DateTime start,
            DateTime end,
            string country)
        {
            var holidays = new List<DateTime>() { };

            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                if (IsSunday(date))
                    continue;

                if (IsNationalHoliday(date, country))
                    continue;

                holidays.Add(date);
            }

            return holidays;
        }

        public static bool IsHolidayValid(int holidayCount)
        {
            return holidayCount <= MaxDayCount;
        }

        public static bool IsSunday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsNationalHoliday(DateTime date, string country)
        {
            return country switch
            {
                Country.Finland => NationalHolidays.FinnishHolidays.Contains(date),
                _ => throw new Exception("Country not supported!"),
            };
        }
    }
}

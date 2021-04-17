using System;
using System.Collections.Generic;
using HolidayPlanner.DateLogic;

namespace HolidayPlanner.HolidayLogic
{
    static class Country
    {
        public const string Finland = "Finland";

        public static IReadOnlyCollection<string> SupportedCountries = new [] { Finland };
    }

    public interface IHolidayService
    {
        bool IsOnSameHolidayPeriod(DateTime start, DateTime end);
        bool IsRangeChronological(DateTime start, DateTime end);
    }

    public class HolidayService : IHolidayService
    {
        private const int MaxDayCount = 50;
        private IDateWrapper dateWrapper;

        public HolidayService(IDateWrapper dateWrapper)
        {
            this.dateWrapper = dateWrapper;
        }


        public bool IsRangeChronological(DateTime start, DateTime end)
        {
            return start < end;
        }

        public bool IsOnSameHolidayPeriod(DateTime start, DateTime end)
        {
            var today = dateWrapper.GetToday();

            // Start should be greater than or equal than today 
            if (start < today)
            {
                return false;
            }

            // If we current date < April 1st, the current holiday period ends on 30th of March
            if (today < new DateTime(today.Year, 4, 1))
            {
                // Start should be smaller than 1st on April AND end should be smaller than 1st of April as well.
                return start < new DateTime(today.Year, 4, 1) && end < new DateTime(start.Year, 4, 1);
            }

            // Current date > 1st of April, so the current holiday period ends next year on March 30th.
            // Start should smaller than 1st on April NEXT YEAR AND end should be smaller than 1st of April NEXT YEAR 
            return start < new DateTime(today.Year + 1, 4, 1) && end < new DateTime(today.Year + 1, 4, 1);

        }

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

        public static bool IsHolidayLengthValid(int holidayCount)
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

        public DateTime GetToday() => DateTime.Now;
    }
}

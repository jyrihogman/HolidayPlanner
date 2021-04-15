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

            if (today < new DateTime(today.Year, 4, 1))
            {
                return start > today && start < new DateTime(today.Year, 4, 1) && end < new DateTime(start.Year, 4, 1);
            }

            return start > today && start < new DateTime(today.Year + 1, 4, 1) && end < new DateTime(start.Year + 1, 4, 1);

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

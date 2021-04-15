using System;
using HolidayPlanner.DateLogic;
using HolidayPlanner.HolidayLogic;

namespace HolidayPlanner
{
    public enum ValidationResult
    {
        Ok,
        InvalidRange,
        TooManyDays,
        InvalidPeriod
    }

    public interface IHolidayPlanner
    {
        (ValidationResult, int) ValidateHoliday(string firstInput, string secondInput, string country = "Finland");
    }

    public class HolidayPlanner : IHolidayPlanner
    {
        private readonly IHolidayService holidayService;


        public HolidayPlanner()
        {}

        public HolidayPlanner(IHolidayService holidayService)
        {
            this.holidayService = holidayService;
        }

        public (ValidationResult, int) ValidateHoliday(string firstInput, string secondInput, string country = "Finland")
        {
            var startDate = DateService.GetDate(firstInput);
            var endDate = DateService.GetDate(secondInput);

            var (isValid, result) = ValidateHolidayRange(startDate, endDate);

            if (!isValid)
            {
                return (result, 0);
            }

            var holidays = HolidayService.GetConsumedHolidays(startDate, endDate, country);

            var holidayCount = holidays.Count;


            return HolidayService.IsHolidayLengthValid(holidayCount) ? 
                (ValidationResult.Ok, holidayCount)
                : 
                (ValidationResult.TooManyDays, holidayCount);
            
        }

        public (bool, ValidationResult) ValidateHolidayRange(DateTime startDate, DateTime endDate)
        {
            var isChronological = holidayService.IsRangeChronological(startDate, endDate);

            var samePeriod = holidayService.IsOnSameHolidayPeriod(startDate, endDate);

            if (samePeriod && isChronological)
                return (true, ValidationResult.Ok);

            if (!samePeriod) 
                return (false, ValidationResult.InvalidPeriod);

            return (false, ValidationResult.InvalidRange);
            
        }
    }
}

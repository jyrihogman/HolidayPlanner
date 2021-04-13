using System;
using System.Collections.Generic;
using System.Text;
using HolidayPlanner.DateLogic;

namespace HolidayPlanner
{
    public static class HolidayPlanner
    { 
        public static (bool, int) IsHolidayValid(string firstInput, string secondInput, string country = "Finland")
        {
            var startDate = DateService.GetDate(firstInput);
            var endDate = DateService.GetDate(secondInput);

            var holidays = HolidayPlannerService.GetConsumedHolidays(startDate, endDate, country);

            var holidayCount = holidays.Count;


            return HolidayPlannerService.IsHolidayValid(holidayCount) ? 
                (true, holidayCount) : (false, holidayCount);
            
        }
    }
}

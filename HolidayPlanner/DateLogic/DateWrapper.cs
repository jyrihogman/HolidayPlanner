using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayPlanner.DateLogic
{
    public interface IDateWrapper
    {
        DateTime GetToday();
    }

    public class DateWrapper : IDateWrapper
    {
        public DateWrapper() { }

        public DateTime GetToday()
        {
            return DateTime.Now;
        }
    }
}

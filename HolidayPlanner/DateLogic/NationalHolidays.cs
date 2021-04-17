using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayPlanner.DateLogic
{

    // MVP for the product is specified so that it only works for Finnish holidays in the current period

    // In the future we should use a 3rd party library to get national holidays for multiple countries
    // Or we can have a scheduled serverless lambda, that calculates the national holidays for supported countries
    // When invoked, and deletes dates from holiday periods that are older than a year for example
    // And stores the newly calculated national holidays on DynamoDB, S3 or a standard SQL database.
    public static class NationalHolidays
    {
        public static List<DateTime> FinnishHolidays = new List<DateTime>
        { 
            new DateTime(2021, 1, 1),
            new DateTime(2021, 1, 6),
            new DateTime(2021, 4, 2),
            new DateTime(2021, 4, 5),
            new DateTime(2021, 5, 13),
            new DateTime(2021, 6, 25),
            new DateTime(2021, 12, 6),
            new DateTime(2021, 12, 24),
            new DateTime(2022, 1, 1),
            new DateTime(2022, 1, 6),
            new DateTime(2022, 4, 15),
            new DateTime(2022, 4, 18),
            new DateTime(2022, 5, 1),
            new DateTime(2022, 5, 26),
            new DateTime(2022, 6, 5),
            new DateTime(2022, 6, 24),
            new DateTime(2022, 12, 6),
            new DateTime(2022, 12, 24),
            new DateTime(2022, 12, 25),
            new DateTime(2022, 12, 26)
        };
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using HolidayPlanner.DateLogic;
using System;

namespace HolidayPlanner.Tests
{
    [TestClass]
    public class DateServiceTests
    {
        [TestMethod]
        public void GetDatePositive()
        {
            var date = "2021.1.1";
            var expectedDate = new DateTime(2021, 1, 1);
            var dateTime = DateService.GetDate(date);
        

            Assert.AreEqual(expectedDate, dateTime);
        }

        [TestMethod]
        public void GetDateNegative()
        {
            var date = "2021.1.5";
            var expectedDate = new DateTime(2021, 1, 1);
            var dateTime = DateService.GetDate(date);


            Assert.AreNotEqual(expectedDate, dateTime);
        }

        [TestMethod]
        public void GetDatePositiveDifferentFormat()
        {
            var date = "1-1-2021";
            var expectedDate = new DateTime(2021, 1, 1);
            var dateTime = DateService.GetDate(date);
        

            Assert.AreEqual(expectedDate, dateTime);
        }
    }
}

using PatientBookingSystem.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PatientBookingSystem.Helpers.Tests {
    [TestClass()]
    public class TimeRangeTests {
        TimeRange instance = new TimeRange(new TimeSpan(9, 30, 0), new TimeSpan(10, 0, 0));
        [TestMethod()]
        public void isInTimeRangeTest() {
            bool expected = true;
            bool result = instance.isInTimeRange(new TimeSpan(9, 45, 0));
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void isInTimeRangeTestNegative() {
            bool expected = false;
            bool result = instance.isInTimeRange(new TimeSpan(10, 45, 0));
            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getTimeRangeTest() {
            string expected = "09:30 - 10:00";
            string result = instance.getTimeRange();
            Assert.AreEqual(expected, result);
        }
    }
}
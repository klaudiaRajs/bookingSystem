using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientBookingSystem.Models.Tests {
    [TestClass()]
    public class ScheduleModelTests {
        ScheduleModel instance = new ScheduleModel();

        /** Method tests if instance correctly removes time from dateTime string */
        [TestMethod()]
        public void setDateTest() {
            string expected = "2017-04-15";
            instance.setDate("2017-04-15 13:00:00");
            string result = instance.getDate();
            Assert.AreEqual(expected, result);
        }
    }
}
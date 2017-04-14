using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientBookingSystem.Models;

namespace PatientBookingSystem.Controllers.Tests {
    /** Class tests testable methods within the booking controller */
    [TestClass()]
    public class BookingControllerTests {
        BookingController instance = new BookingController();
        
        /** Method tests if correct attendance status is returned based on input */
        [TestMethod()]
        public void getAttendanceTextPerBookingTestAttendedOnTime() {
            BookingModel booking = new BookingModel();
            booking.setAttendance(1);
            booking.setConfirmation(1);
            booking.setLackOfCancellation(0);

            string expected = instance.getOnTimeAppointmentStatus();
            string result = instance.getAttendanceTextPerBooking(booking);
            Assert.AreEqual(expected, result);
        }

        /** Method tests if correct attendance status is returned based on input */
        [TestMethod()]
        public void getAttendanceTextPerBookingTestAttendedLate() {
            BookingModel booking = new BookingModel();
            booking.setAttendance(2);
            booking.setConfirmation(1);
            booking.setLackOfCancellation(0);

            string expected = instance.getLateAppointmentStatus();
            string result = instance.getAttendanceTextPerBooking(booking);
            Assert.AreEqual(expected, result);
        }

        /** Method tests if correct attendance status is returned based on input */
        [TestMethod()]
        public void getAttendanceTextPerBookingTestCancelled() {
            BookingModel booking = new BookingModel();
            booking.setAttendance(0);
            booking.setConfirmation(0);
            booking.setLackOfCancellation(0);

            string expected = instance.getCancelledAppointmentStatus();
            string result = instance.getAttendanceTextPerBooking(booking);
            Assert.AreEqual(expected, result);
        }

        /** Method tests if correct attendance status is returned based on input */
        [TestMethod()]
        public void getAttendanceTextPerBookingTestIgnored() {
            BookingModel booking = new BookingModel();
            booking.setAttendance(1);
            booking.setConfirmation(1);
            booking.setLackOfCancellation(1);

            string expected = instance.getIgnoredAppointmentStatus();
            string result = instance.getAttendanceTextPerBooking(booking);
            Assert.AreEqual(expected, result);
        }

        /** Method tests if correct attendance status is returned based on input */
        [TestMethod()]
        public void getAttendanceTextPerBookingTestIncorrectData() {
            BookingModel booking = new BookingModel();
            booking.setAttendance(1);
            booking.setConfirmation(2);
            booking.setLackOfCancellation(1);

            string expected = instance.getIncorrectDataAppointmentStatus();
            string result = instance.getAttendanceTextPerBooking(booking);
            Assert.AreEqual(expected, result);
        }

        /** Method tests if correct attendance status is returned based on input */
        [TestMethod()]
        public void getAttendanceTextPerBookingTestNotConfirmed() {
            BookingModel booking = new BookingModel();
            booking.setAttendance(0);
            booking.setConfirmation(2);
            booking.setLackOfCancellation(0);

            string expected = instance.getNotConfirmedAppointmentStatus();
            string result = instance.getAttendanceTextPerBooking(booking);
            Assert.AreEqual(expected, result);
        }
    }
}
using System;
using System.Linq;
using System.Windows.Forms;
using PatientBookingSystem.Models;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Controllers;

namespace PatientBookingSystem {
    /** Class is responsible for manipulating elements of the presenter and communication between homePanel and booking controller */
    partial class homePanel : UserControl {

        public homePanel() {
            InitializeComponent();
            adjustPresenterBasedOnUserType(); 
        }

        /** Method adjusts the view based on user type */
        private void adjustPresenterBasedOnUserType() {
            BookingController controller = new BookingController(); 
            if (ApplicationState.userType != "admin") {
                theMostRecentAppointment.Text += getDateInPresenterFormat(controller.getLastAppointment());
                theMostAttendandedDoctor.Text += controller.getTheMostOftenAttendedDoctor();
                if (controller.getTheMostOftenAttendedNurse().Count != 0) {
                    theMostAttendendedNurse.Text += (controller.getTheMostOftenAttendedNurse().First() as StaffModel).getFullStaffName();
                } else {
                    theMostAttendendedNurse.Text += " no nurse appointments";
                }
            } else {
                theMostAttendandedDoctor.Visible = false;
                theMostAttendendedNurse.Visible = false;
                theMostRecentAppointment.Visible = false;
                essentailInformationLabel.Visible = false;
                personalStatistics.Visible = false;
            }
        }

        /** Method converts date based to format displayable in the view */
        protected string getDateInPresenterFormat(string date) {
            string[] separator = new string[] { ".", " " };
            if (String.IsNullOrEmpty(date)) {
                return null;
            }
            string[] dateContent = date.Split(separator, StringSplitOptions.None);
            DateTime newDate = new DateTime(Int32.Parse(dateContent[2]), Int32.Parse(dateContent[1]), Int32.Parse(dateContent[0]));
            String dateInFormat = newDate.ToString("dddd dd MMMM, yyyy");
            return dateInFormat;
        }
    }
}

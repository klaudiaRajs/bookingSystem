using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Models;
using PatientBookingSystem.Helpers;

namespace PatientBookingSystem {
    partial class homePanel : UserControl {
        BookingRepo repo;
        List<IModel> bookingRepo;

        public homePanel() {
            InitializeComponent();
            repo = new BookingRepo();
            bookingRepo = repo.getBookingsPerUser();
            if (ApplicationState.userType != "admin") {
                theMostRecentAppointment.Text += getDateInPresenterFormat(repo.getLastAppointment());
                theMostAttendandedDoctor.Text += repo.getTheMostAttendedDoctor().getFullStaffName();
                if (repo.getTheMostAttendedNurse().Count != 0) {
                    theMostAttendendedNurse.Text += (repo.getTheMostAttendedNurse().First() as StaffModel).getFullStaffName();
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

        protected String getDateInPresenterFormat(String date) {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PatientBookingSystem.Controllers;
using PatientBookingSystem.Repositories;
using PatientBookingSystem.Models;
using PatientBookingSystem.Presenters;
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
            //debugger();
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

        //public void debugger() {
        //    Dictionary<int, BookingModel> booking = repo.getAllUpcomingAppointments();
        //    for (int i = 0; i < booking.Count(); i++) {
        //        debuggerTextBox.Text += System.Environment.NewLine + "id: " + booking[i].getId().ToString();
        //        debuggerTextBox.Text += System.Environment.NewLine + "confirmation: " + booking[i].getConfirmation().ToString();
        //        debuggerTextBox.Text += System.Environment.NewLine + "attendance: " + booking[i].getAttendance().ToString();
        //        debuggerTextBox.Text += System.Environment.NewLine + "lackOfConfirmation: " + booking[i].getLackOfCancellation().ToString();
        //        if (booking[i].getComment() == null) {
        //            debuggerTextBox.Text += "";
        //        } else {
        //            debuggerTextBox.Text += System.Environment.NewLine + "comment: " + booking[i].getComment().ToString();
        //        }
        //        debuggerTextBox.Text += System.Environment.NewLine + "startTime: " + booking[i].getStartTime().ToString();
        //        debuggerTextBox.Text += System.Environment.NewLine + "endTime: " + booking[i].getEndTime().ToString();
        //        debuggerTextBox.Text += System.Environment.NewLine + "staffName: " + booking[i].getStaffModel().getFirstName();
        //        debuggerTextBox.Text += System.Environment.NewLine + "staffName: " + booking[i].getStaffModel().getLastName();
        //        debuggerTextBox.Text += System.Environment.NewLine + "date: " + booking[i].getScheduleModel().getDate();
        //    }
        //}
    }
}

using PatientBookingSystem.Controllers;
using PatientBookingSystem.Helpers;
using PatientBookingSystem.Models;
using PatientBookingSystem.Presenters.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MainViews {
    /** Class is responsible for managing attendance edit window and passing data to the relevant controllers */
    public partial class AttendanceEditWindow : Form {

        private BookingModel booking;
        private AppointmentBoxI parent;
        private const string ATTENDANCE_OPTION_NOT_SELECTED = "Please select attendance status!";

        /** 
         * Constructor 
         * 
         * @param parent a view class implementing AppointmentBoxI interface 
         * @param booking BookingModel
         */
        public AttendanceEditWindow(AppointmentBoxI parent, BookingModel booking) {
            InitializeComponent();
            this.booking = booking;
            this.parent = parent;
            fillInAppointmentData();
            prepareAtendanceOptionsDropDown();
            this.CenterToScreen();
        }

        /** Method fills in appointment data */
        private void fillInAppointmentData() {
            patientsName.Text = this.booking.getUserModel().getFullName();
            appointmentDate.Text = this.booking.getScheduleModel().getDate();
            appointmentTime.Text = this.booking.getStartTime();
        }

        /** Method prepares attendance options drop-down */
        private void prepareAtendanceOptionsDropDown() {
            ListItem lists = new ListItem();
            List<ListItem> attendanceOptionsDataSource = lists.getDateSourceOfAllPossibleAttendanceStatuses();
            attendanceOptions.DropDownStyle = ComboBoxStyle.DropDownList;
            attendanceOptions.DataSource = attendanceOptionsDataSource;
            attendanceOptions.DisplayMember = "text";
            attendanceOptions.ValueMember = "id";
        }

        /** Method initiaties the process of updating the attendance process */
        private void saveButton_Click(object sender, System.EventArgs e) {
            FeedbackWindow message = new FeedbackWindow();
            if (attendanceOptions.SelectedIndex != 0) {
                BookingController controller = new BookingController();
                string selectedOption = (attendanceOptions.SelectedItem as ListItem).text;
                Dictionary<string, int> options = controller.getAttendanceOptions()[selectedOption];
                booking.setAttendance(options["attendance"]);
                booking.setConfirmation(options["confirmation"]);
                booking.setLackOfCancellation(options["lackOfCancellation"]);
                if (controller.updateAttendanceStatus(booking)) {
                    message.setMessageForSuccessfullOperation();
                } else {
                    message.setMessageForSavingError();
                }
                parent.getAppointmentBoxes();
                this.Hide();
            } else {
                message.setCustomizedMessage(ATTENDANCE_OPTION_NOT_SELECTED);
            }
            message.Show();
        }

        /** Method allows closing the window by pressing "Esc" */
        private void AttendanceEditWindow_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Hide();
            }
        }
    }
}

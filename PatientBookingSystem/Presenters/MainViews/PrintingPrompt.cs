using PatientBookingSystem.Controllers;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MainViews {
    /** Class is responsible for managing printing prompt view */
    public partial class PrintingPrompt : Form {

        private string date;
        private string startTime; 
        private string endTime;
        private string appointmentType;
        private string staffName; 

        /** 
         * Constructor 
         * 
         * @param date
         * @param startTime
         * @param endTime
         * @param staffName
         * @param staffScheduleId
         */
        public PrintingPrompt(string date, string startTime, string endTime, string staffName, int staffScheduleId) {
            InitializeComponent();
            StaffController staffController = new StaffController();
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;
            this.staffName = staffName;
            this.appointmentType = staffController.getStaffTypeByStaffScheduleId(staffScheduleId);
            this.CenterToScreen();
        }


        private void printButton_Click(object sender, System.EventArgs e) {
            PrintConfirmationWindow printingWindow = new PrintConfirmationWindow(this.date, this.startTime, this.staffName, this.appointmentType);
            printingWindow.Show();
            this.Hide();
        }

        private void cancelButton_Click(object sender, System.EventArgs e) {
            this.Hide();
        }
    }
}

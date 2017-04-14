using PatientBookingSystem.Presenters.MinorElements;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MainViews {
    /** Class is responsible for managign print confirmation window and for printing a confirmation */
    partial class PrintConfirmationWindow : Form {

        string date;
        string time;
        string staffName;
        string typeOfAppointment;

        /** Constructor initializes fields and build the view up */
        public PrintConfirmationWindow(string date, string time, string staffName, string typeOfAppointment, appointmentBox parent) {
            InitializeComponent();
            this.date = date;
            this.time = time;
            this.staffName = staffName;
            this.typeOfAppointment = typeOfAppointment;
            fillInData();
            this.CenterToScreen();
        }

        /** Method fills in the form */
        private void fillInData() {
            dateLabel.Text = this.date;
            timeLabel.Text = this.time;
            staffNameLabel.Text = this.staffName;
            typeOfAppointmentLabel.Text = this.typeOfAppointment; 
        }

        /** Method closes the window */
        private void homeButton_Click(object sender, EventArgs e) {
            this.Hide();
        }

        /** Method fires printing process */
        private void printButton_Click(object sender, EventArgs e) {
            prepareViewForPrinting();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintImage);
            pd.Print();
            this.Close();
        }

        /** Method prepares view for printing */
        private void prepareViewForPrinting() {
            this.BackColor = System.Drawing.Color.White;
            dateLabel.BackColor = System.Drawing.Color.White;
            timeLabel.BackColor = System.Drawing.Color.White;
            staffNameLabel.BackColor = System.Drawing.Color.White;
            typeOfAppointmentLabel.BackColor = System.Drawing.Color.White;
            appointmentDate.BackColor = System.Drawing.Color.White;
            timeLabelLabel.BackColor = System.Drawing.Color.White;
            staffNameLabelLabel.BackColor = System.Drawing.Color.White;
            typeOfAppointmentLabelLabel.BackColor = System.Drawing.Color.White;
        }

        /** Method prints the image of the confirmation window */
        private void PrintImage(object o, PrintPageEventArgs e) {
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
            int width = this.Width;
            int height = this.Height;

            Rectangle bounds = new Rectangle(x, y, width, height);

            Bitmap img = new Bitmap(width, height);

            this.DrawToBitmap(img, bounds);
            Point p = new Point(100, 100);
            e.Graphics.DrawImage(img, p);
        }
    }
}

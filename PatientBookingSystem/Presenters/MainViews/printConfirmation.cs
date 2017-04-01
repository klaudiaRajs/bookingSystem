using PatientBookingSystem.Presenters.MinorElements;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PatientBookingSystem.Presenters.MainViews {
    partial class printConfirmation : Form {
        string date;
        string time;
        string staffName;
        string typeOfAppointment;
        appointmentBox parent;

        public printConfirmation(string date, string time, string staffName, string typeOfAppointment, appointmentBox parent) {
            InitializeComponent();
            this.parent = parent; 
            this.date = date;
            this.time = time;
            this.staffName = staffName;
            this.typeOfAppointment = typeOfAppointment;
            fillInData(); 
        }

        private void fillInData() {
            dateLabel.Text = this.date;
            timeLabel.Text = this.time;
            staffNameLabel.Text = this.staffName;
            typeOfAppointmentLabel.Text = this.typeOfAppointment; 
        }

        private void homeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void printButton_Click(object sender, EventArgs e) {
            prepareViewForPrinting();
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintImage);
            pd.Print();
            this.Close();
        }

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

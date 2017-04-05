using System;
using System.Windows.Forms;

namespace PatientBookingSystem {
    /** Class is responsible for displaying and closing help window */
    public partial class HelpWindow : Form {

        public HelpWindow() {
            InitializeComponent();
        }

        /** Method closes the help window  */
        private void exitButton_Click(object sender, EventArgs e) {
            this.Close(); 
        }

        /** Method sets the message */
        public void setHelpMessage(string helpMessage) {
            contentText.Text = helpMessage; 
        }
    }
}

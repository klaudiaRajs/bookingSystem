using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientBookingSystem {
    public partial class Help : Form {
        public Help() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        //przekaz tutaj jakiegos ENUMA i ta wiadomosc generowac tutaj
        public void setHelpMessage(string helpMessage) {
            richTextBox1.Text = helpMessage; 
        }
    }
}

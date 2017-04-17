using System.Windows.Forms;

namespace PatientBookingSystem {
    /** Class is a representation of a initialInstructionPanel */
    public partial class initialInstructionsPanel : UserControl {

        public initialInstructionsPanel() {
            InitializeComponent();
            introductionPanel.SelectAll();
            introductionPanel.BackColor = System.Drawing.Color.LightSlateGray;
            introductionPanel.SelectionAlignment = HorizontalAlignment.Center;
        }
    }
}

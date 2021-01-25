using System;
using System.Windows.Forms;

namespace OCLSA_Project_Version_01
{
    public partial class CalibratedFsoInputForm : Form
    {
        public string AppliedLoad
        {
            get { return _appliedLoad; }
        }

        public string Capacity
        {
            get { return _capacity; }
        }

        private string _appliedLoad;
        private string _capacity;

        public CalibratedFsoInputForm()
        {
            InitializeComponent();
        }

        private void btnOperatorLogin_Click(object sender, EventArgs e)
        {
            if (cbAppliedLoad.SelectedIndex < -1 || tbCapacity.Text == "")
            {
                MessageBox.Show(@"Fill all the fields...");
                return;
            }

            _appliedLoad = cbAppliedLoad.Text;
            _capacity = tbCapacity.Text;

            MessageBox.Show(@"Press OK to continue...");

            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            var result = MessageBox.Show(@"Do you want to exit?", @"Select Option", buttons);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
    }
}

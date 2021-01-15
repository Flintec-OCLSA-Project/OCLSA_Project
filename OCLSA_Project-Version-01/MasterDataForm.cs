using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OCLSA_Project_Version_01.Models;

namespace OCLSA_Project_Version_01
{
    public partial class MasterDataForm : Form
    {
        private ApplicationDbContext _context;

        public MasterDataForm()
        {
            InitializeComponent();

            tbCornersTrimValue.Enabled = false;
            EnableOrDisableCornerInputs(false);
            EnableOrDisableInputs(false);
            rbSameValue.Enabled = false;
            rbDifferentValues.Enabled= false;

            _context = new ApplicationDbContext();
        }

        private void EnableOrDisableCornerInputs(bool command)
        {
            var cornerInputsList = new List<Control> 
            { 
                tbLeftCornerTrimValue, tbBackCornerTrimValue, tbRightCornerTrimValue, tbFrontCornerTrimValue,
                tbLeftFrontCornerTrimValue, tbLeftBackCornerTrimValue, tbRightBackCornerTrimValue, tbRightFrontCornerTrimValue
            };

            foreach (var corner in cornerInputsList)
            {
                corner.Enabled = command;
            }
        }

        private void EnableOrDisableInputs(bool command)
        {
            var inputsList = new List<Control>
            {
                cbLoadCellType, cbTestMode, tbMinimumUnbalance, tbMaximumUnbalance, tbMinimumFso, tbMaximumFso,
                tbMaximumCenter, tbFrontBackCornerDifference, tbLeftRightCornerDifference, tbExcessiveCornerValue, btnSave, btnCancel
            };

            foreach (var input in inputsList)
            {
                input.Enabled = command;
            }
        }

        private void tbSerialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Return)) return;

            if (tbSerialNumber.Text == "")
            {
                MessageBox.Show(@"Please Enter the Serial Number...");
                return;
            }

            var loadCellInDb = _context.LoadCells.SingleOrDefault(l => l.SerialNumber == tbSerialNumber.Text);

            if (loadCellInDb != null)
            {
                MessageBox.Show(@"Load Cell is already existing...");
                tbSerialNumber.Clear();

                //Display the current load cell information in suitable fields

                Application.Exit();

                return;
            }

            MessageBox.Show(@"Enter Load Cell information...");
            EnableOrDisableInputs(true);
            rbSameValue.Enabled = true;
            rbDifferentValues.Enabled = true;
        }

        private string _leftCornerTrimValue;
        private string _backCornerTrimValue;
        private string _rightCornerTrimValue;
        private string _frontCornerTrimValue;

        private string _leftFrontCornerTrimValue;
        private string _leftBackCornerTrimValue;
        private string _rightBackCornerTrimValue;
        private string _rightFrontCornerTrimValue;

        private string _cornersTrimValue;

        private void GetAllDetails()
        {
            var serialNumber = tbSerialNumber.Text;
            var loadCellType = cbLoadCellType.Text;

            var minimumUnbalance = tbMinimumUnbalance.Text;
            var maximumUnbalance = tbMaximumUnbalance.Text;
            var minimumFso = tbMinimumFso.Text;
            var maximumFso = tbMaximumFso.Text;
            var maximumCenter = tbMaximumCenter.Text;

            _cornersTrimValue = tbCornersTrimValue.Text;

            _leftCornerTrimValue = tbLeftCornerTrimValue.Text;
            _backCornerTrimValue = tbBackCornerTrimValue.Text;
            _rightCornerTrimValue = tbRightCornerTrimValue.Text;
            _frontCornerTrimValue = tbFrontCornerTrimValue.Text;

            _leftFrontCornerTrimValue = tbLeftFrontCornerTrimValue.Text;
            _leftBackCornerTrimValue = tbLeftBackCornerTrimValue.Text;
            _rightBackCornerTrimValue = tbRightBackCornerTrimValue.Text;
            _rightFrontCornerTrimValue = tbRightFrontCornerTrimValue.Text;

            var leftRightCornerDifference = tbLeftRightCornerDifference.Text;
            var frontBackCornerDifference = tbFrontBackCornerDifference.Text;
            var excessiveCornerValue = tbExcessiveCornerValue.Text;

        }

        private void rbSameValue_CheckedChanged(object sender, EventArgs e)
        {
            tbCornersTrimValue.Enabled = true;

            if (rbDifferentValues.Checked)
            {
                tbCornersTrimValue.Clear();
                tbCornersTrimValue.Enabled = false;
            }
        }

        private void rbDifferentValues_CheckedChanged(object sender, EventArgs e)
        {
            EnableOrDisableCornerInputs(true);

            var cornerInputsList = new List<Control>
            {
                tbLeftCornerTrimValue, tbBackCornerTrimValue, tbRightCornerTrimValue, tbFrontCornerTrimValue,
                tbLeftFrontCornerTrimValue, tbLeftBackCornerTrimValue, tbRightBackCornerTrimValue, tbRightFrontCornerTrimValue
            };

            if (rbSameValue.Checked)
            {
                foreach (var corner in cornerInputsList)
                {
                    corner.Text = "";
                }

                EnableOrDisableCornerInputs(false);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var textControlsWithOneCorner = new List<Control>
            {
                tbSerialNumber, cbLoadCellType, cbTestMode, tbMinimumUnbalance, tbMaximumUnbalance, tbMinimumFso, tbMaximumFso,
                tbMaximumCenter, tbFrontBackCornerDifference, tbLeftRightCornerDifference, tbExcessiveCornerValue, tbCornersTrimValue
            };

            var textControlsWithAllCorners = new List<Control>
            {
                tbSerialNumber, cbLoadCellType, cbTestMode, tbMinimumUnbalance, tbMaximumUnbalance, tbMinimumFso, tbMaximumFso,
                tbMaximumCenter, tbFrontBackCornerDifference, tbLeftRightCornerDifference, tbExcessiveCornerValue, tbLeftCornerTrimValue,
                tbBackCornerTrimValue, tbRightCornerTrimValue, tbFrontCornerTrimValue, tbLeftFrontCornerTrimValue, tbLeftBackCornerTrimValue, 
                tbRightBackCornerTrimValue, tbRightFrontCornerTrimValue
            };

            
            var isEmptyAnyControl = textControlsWithOneCorner
                                        .Any(t => string.IsNullOrWhiteSpace(t.Text));

            var isEmptyAny = textControlsWithAllCorners
                                        .Any(t => string.IsNullOrWhiteSpace(t.Text));

            if ((!rbSameValue.Checked || isEmptyAnyControl) && (!rbDifferentValues.Checked || isEmptyAny))
            {
                MessageBox.Show(@"Fill all relevant fields...");
                return;
            }

            

            MessageBox.Show(@"Ok...");



        }

    }
}

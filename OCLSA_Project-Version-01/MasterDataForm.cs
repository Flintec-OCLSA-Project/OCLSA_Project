using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OCLSA_Project_Version_01.Models;
using Type = OCLSA_Project_Version_01.Models.Type;

namespace OCLSA_Project_Version_01
{
    public partial class MasterDataForm : Form
    {
        private ApplicationDbContext _context;

        public MasterDataForm()
        {
            InitializeComponent();
            EnableOrDisableControls();

            btnEdit.Hide();

            _context = new ApplicationDbContext();
        }

        private void EnableOrDisableCornerInputs(bool command)
        {
            var cornerInputsList = new List<Control> 
            { 
                tbLeftCornerTrimValue, tbBackCornerTrimValue, tbRightCornerTrimValue, tbFrontCornerTrimValue,
                tbFrontLeftCornerTrimValue, tbBackLeftCornerTrimValue, tbBackRightCornerTrimValue, tbFrontRightCornerTrimValue
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
                const string message = "Load Cell is already existing. Do you want to edit the load cell?";
                const string title = "Choose Option";
                const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                var result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    btnSave.Hide();
                    btnEdit.Show();

                    //Display the current load cell information in suitable fields

                }
                else
                {
                    tbSerialNumber.Clear();
                }

                return;
            }

            MessageBox.Show(@"Enter Load Cell information...");
            EnableOrDisableInputs(true);
            rbSameValue.Enabled = true;
            rbDifferentValues.Enabled = true;
        }

        private void rbSameValue_CheckedChanged(object sender, EventArgs e)
        {
            tbCornersTrimValue.Enabled = true;

            if (!rbDifferentValues.Checked) return;
            tbCornersTrimValue.Clear();
            tbCornersTrimValue.Enabled = false;
        }

        private void rbDifferentValues_CheckedChanged(object sender, EventArgs e)
        {
            EnableOrDisableCornerInputs(true);

            var cornerInputsList = new List<Control>
            {
                tbLeftCornerTrimValue, tbBackCornerTrimValue, tbRightCornerTrimValue, tbFrontCornerTrimValue,
                tbFrontLeftCornerTrimValue, tbBackLeftCornerTrimValue, tbBackRightCornerTrimValue, tbFrontRightCornerTrimValue
            };

            if (!rbSameValue.Checked) return;

            foreach (var corner in cornerInputsList)
            {
                corner.Text = "";
            }

            EnableOrDisableCornerInputs(false);

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
                tbBackCornerTrimValue, tbRightCornerTrimValue, tbFrontCornerTrimValue, tbFrontLeftCornerTrimValue, tbBackLeftCornerTrimValue, 
                tbBackRightCornerTrimValue, tbFrontRightCornerTrimValue
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

            try
            {
                var loadCell = new LoadCell
                {
                    SerialNumber = tbSerialNumber.Text,
                    Type = new Type
                    {
                        Name = RemoveWhitespace(cbLoadCellType.Text),
                        TestMode = RemoveWhitespace(cbTestMode.Text),
                        MaximumCenterValue = Convert.ToDouble(tbMaximumCenter.Text),
                        LeftCornerTrimValue = string.IsNullOrWhiteSpace(tbLeftCornerTrimValue.Text) ? 0d : Convert.ToDouble(tbLeftCornerTrimValue.Text),
                        BackCornerTrimValue = string.IsNullOrWhiteSpace(tbBackCornerTrimValue.Text) ? 0d : Convert.ToDouble(tbBackCornerTrimValue.Text),
                        RightCornerTrimValue = string.IsNullOrWhiteSpace(tbRightCornerTrimValue.Text) ? 0d : Convert.ToDouble(tbRightCornerTrimValue.Text),
                        FrontCornerTrimValue = string.IsNullOrWhiteSpace(tbFrontCornerTrimValue.Text) ? 0d : Convert.ToDouble(tbFrontCornerTrimValue.Text),
                        FrontLeftCornerTrimValue = string.IsNullOrWhiteSpace(tbFrontLeftCornerTrimValue.Text) ? 0d : Convert.ToDouble(tbFrontLeftCornerTrimValue.Text),
                        BackLeftCornerTrimValue = string.IsNullOrWhiteSpace(tbBackLeftCornerTrimValue.Text) ? 0d : Convert.ToDouble(tbBackLeftCornerTrimValue.Text),
                        BackRightCornerTrimValue = string.IsNullOrWhiteSpace(tbBackRightCornerTrimValue.Text) ? 0d : Convert.ToDouble(tbBackRightCornerTrimValue.Text),
                        FrontRightCornerTrimValue = string.IsNullOrWhiteSpace(tbFrontRightCornerTrimValue.Text) ? 0d : Convert.ToDouble(tbFrontRightCornerTrimValue.Text),
                        CornerTrimValue = string.IsNullOrWhiteSpace(tbCornersTrimValue.Text) ? 0d : Convert.ToDouble(tbCornersTrimValue.Text),
                        ExcessiveCornerValue = Convert.ToDouble(tbExcessiveCornerValue.Text),
                        FrontBackCornerDifference = Convert.ToDouble(tbFrontBackCornerDifference.Text),
                        LeftRightCornerDifference = Convert.ToDouble(tbLeftRightCornerDifference.Text),
                        MinimumUnbalanceValue = Convert.ToDouble(tbMinimumUnbalance.Text),
                        MaximumUnbalanceValue = Convert.ToDouble(tbMaximumUnbalance.Text),
                        MinimumFsoValue = Convert.ToDouble(tbMinimumFso.Text),
                        MaximumFsoValue = Convert.ToDouble(tbMaximumFso.Text)
                    }
                };

                _context.LoadCells.Add(loadCell);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            const string message = "New load cell is added. Do you want to add another load cell?";
            const string title = "Choose Option";
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            var result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                ClearControls();
                EnableOrDisableControls();
            }
            else
            {
                Application.Exit();
            }
        }

        private void EnableOrDisableControls()
        {
            tbCornersTrimValue.Enabled = false;
            EnableOrDisableCornerInputs(false);
            EnableOrDisableInputs(false);
            rbSameValue.Enabled = false;
            rbDifferentValues.Enabled = false;
        }

        private string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }

        private void ClearControls()
        {
            var controls = new List<Control>
            {
                tbSerialNumber, cbLoadCellType, cbTestMode, tbMinimumUnbalance, tbMaximumUnbalance, tbMinimumFso, tbMaximumFso,
                tbMaximumCenter, tbFrontBackCornerDifference, tbLeftRightCornerDifference, tbExcessiveCornerValue, tbLeftCornerTrimValue,
                tbBackCornerTrimValue, tbRightCornerTrimValue, tbFrontCornerTrimValue, tbFrontLeftCornerTrimValue, tbBackLeftCornerTrimValue,
                tbBackRightCornerTrimValue, tbFrontRightCornerTrimValue, tbCornersTrimValue
            };

            var checkBoxControls = new List<RadioButton>
            {
                rbSameValue, rbDifferentValues
            };

            foreach (var control in controls)
            {
                control.Text = "";
            }

            foreach (var checkBoxControl in checkBoxControls)
            {
                checkBoxControl.Checked = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
    }
}

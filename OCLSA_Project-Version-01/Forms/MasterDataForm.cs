using OCLSA_Project_Version_01.DataAccess.MasterDataForm;
using OCLSA_Project_Version_01.Models;
using OCLSA_Project_Version_01.WorkFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TextBox = WindowsFormsAero.TextBox;

namespace OCLSA_Project_Version_01.Forms
{
    public partial class MasterDataForm : Form
    {
        public readonly ApplicationDbContext Context;
        public LoadCellData LoadCellData { get; }

        public TextBox TbTestMode { set; get; }
        public TextBox TbMaximumCenter { set; get; }
        public TextBox TbLeftCornerTrimValue { set; get; }
        public TextBox TbBackCornerTrimValue { set; get; }
        public TextBox TbRightCornerTrimValue { set; get; }
        public TextBox TbFrontCornerTrimValue { set; get; }
        public TextBox TbFrontLeftCornerTrimValue { set; get; }
        public TextBox TbBackLeftCornerTrimValue { set; get; }
        public TextBox TbBackRightCornerTrimValue { set; get; }
        public TextBox TbFrontRightCornerTrimValue { set; get; }
        public TextBox TbCornersTrimValue { set; get; }
        public TextBox TbExcessiveCornerValue { set; get; }
        public TextBox TbFrontBackCornerDifference { set; get; }
        public TextBox TbLeftRightCornerDifference { set; get; }
        public TextBox TbMinimumUnbalance { set; get; }
        public TextBox TbMaximumUnbalance { set; get; }
        public TextBox TbMinimumFso { set; get; }
        public TextBox TbMaximumFso { set; get; }
        public TextBox TbAppliedLoad { set; get; }
        public TextBox TbFullLoad { set; get; }
        public TextBox TbFactor { set; get; }
        public TextBox TbFsoCorrectionValue { set; get; }

        public MasterDataForm()
        {
            InitializeComponent();
            DisableControls();

            btnEdit.Hide();

            Context = new ApplicationDbContext();
            LoadCellData = new LoadCellData(this);
        }

        private void tbLoadCellType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Return)) return;

            if (tbLoadCellType.Text == "")
            {
                MessageBox.Show(@"Please Enter the Load Cell Type...");
                return;
            }

            var loadCellTypeInDb = LoadCellData.FindLoadCellTypeInDb();

            if (loadCellTypeInDb != null)
            {
                var messageBoxResult = ResultMessage.Result("Load Cell Type is already existing. Do you want to edit the Load Cell Type?", "Choose Option");

                if (messageBoxResult == DialogResult.Yes)
                {
                    btnSave.Hide();
                    btnEdit.Show();

                    EnableOrDisableInputs(true);
                    rbSameValue.Enabled = true;
                    rbDifferentValues.Enabled = true;

                    if (loadCellTypeInDb.CornerTrimValue != 0d)
                        rbSameValue.Checked = true;
                    else
                        rbDifferentValues.Checked = true;

                    LoadCellData.DisplayLoadCellTypeData(loadCellTypeInDb, this);
                }
                else
                    tbLoadCellType.Clear();

                return;
            }

            MessageBox.Show(@"Enter New Load Cell Type Information...");
            EnableOrDisableInputs(true);
            rbSameValue.Enabled = true;
            rbDifferentValues.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckAllInputs()) return;

            LoadCellData.SaveLoadCellTypeDataToDb(this);

            var messageBoxResult = ResultMessage.Result("New Load Cell Type is added. Do you want to add another Load Cell Type?",
                "Choose Option");

            if (messageBoxResult == DialogResult.Yes)
            {
                ClearControls();
                DisableControls();
            }
            else
                Application.Exit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckAllInputs()) return;

            var loadCellTypeExisting = LoadCellData.FindExistingLoadCellType(this);

            if (loadCellTypeExisting == null) return;

            LoadCellData.EditLoadCellTypeDataInDb(loadCellTypeExisting, this);

            MessageBox.Show(@"Load Cell Type is updated successfully...");

            ClearControls();
            DisableControls();

            btnEdit.Hide();
            btnSave.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var messageBoxResult = ResultMessage.Result("Do you want to exit?", "Choose Option");

            if (messageBoxResult == DialogResult.Yes) Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rbSameValue_CheckedChanged(object sender, EventArgs e)
        {
            TbCornersTrimValue.Enabled = true;

            if (!rbDifferentValues.Checked) return;
            TbCornersTrimValue.Clear();
            TbCornersTrimValue.Enabled = false;
        }

        private void rbDifferentValues_CheckedChanged(object sender, EventArgs e)
        {
            EnableOrDisableCornerInputs(true);

            var cornerInputsList = new List<Control>
            {
                TbLeftCornerTrimValue, TbBackCornerTrimValue, TbRightCornerTrimValue, TbFrontCornerTrimValue,
                TbFrontLeftCornerTrimValue, TbBackLeftCornerTrimValue, TbBackRightCornerTrimValue, TbFrontRightCornerTrimValue
            };

            if (!rbSameValue.Checked) return;

            foreach (var corner in cornerInputsList)
            {
                corner.Text = "";
            }

            EnableOrDisableCornerInputs(false);

        }

        private bool CheckAllInputs()
        {
            var textControlsWithOneCorner = new List<Control>
            {
                tbLoadCellType, TbTestMode, TbMinimumUnbalance, TbMaximumUnbalance, TbMinimumFso, TbMaximumFso,
                TbMaximumCenter, TbFrontBackCornerDifference, TbLeftRightCornerDifference, TbExcessiveCornerValue,
                TbCornersTrimValue, TbAppliedLoad, TbFullLoad, TbFactor, TbFsoCorrectionValue
            };

            var textControlsWithAllCorners = new List<Control>
            {
                tbLoadCellType, TbTestMode, TbMinimumUnbalance, TbMaximumUnbalance, TbMinimumFso, TbMaximumFso,
                TbMaximumCenter, TbFrontBackCornerDifference, TbLeftRightCornerDifference, TbExcessiveCornerValue,
                TbLeftCornerTrimValue, TbBackCornerTrimValue, TbRightCornerTrimValue, TbFrontCornerTrimValue,
                TbFrontLeftCornerTrimValue, TbBackLeftCornerTrimValue, TbBackRightCornerTrimValue,
                TbFrontRightCornerTrimValue, TbAppliedLoad, TbFullLoad, TbFactor, TbFsoCorrectionValue
            };


            var isEmptyAnyControl = textControlsWithOneCorner
                .Any(t => string.IsNullOrWhiteSpace(t.Text));

            var isEmptyAny = textControlsWithAllCorners
                .Any(t => string.IsNullOrWhiteSpace(t.Text));

            if ((!rbSameValue.Checked || isEmptyAnyControl) && (!rbDifferentValues.Checked || isEmptyAny))
            {
                MessageBox.Show(@"Fill all relevant fields...");
                return true;
            }

            return false;
        }

        private void EnableOrDisableCornerInputs(bool command)
        {
            var cornerInputsList = new List<Control>
            {
                TbLeftCornerTrimValue, TbBackCornerTrimValue, TbRightCornerTrimValue, TbFrontCornerTrimValue,
                TbFrontLeftCornerTrimValue, TbBackLeftCornerTrimValue, TbBackRightCornerTrimValue, TbFrontRightCornerTrimValue
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
                TbTestMode, TbMinimumUnbalance, TbMaximumUnbalance, TbMinimumFso, TbMaximumFso,
                TbMaximumCenter, TbFrontBackCornerDifference, TbLeftRightCornerDifference, TbExcessiveCornerValue, btnSave,
                TbAppliedLoad, TbFullLoad, TbFactor, TbFsoCorrectionValue
            };

            foreach (var input in inputsList)
            {
                input.Enabled = command;
            }
        }

        private void DisableControls()
        {
            TbCornersTrimValue.Enabled = false;
            EnableOrDisableCornerInputs(false);
            EnableOrDisableInputs(false);
            rbSameValue.Enabled = false;
            rbDifferentValues.Enabled = false;
        }

        private void ClearControls()
        {
            var controls = new List<Control>
            {
                tbLoadCellType, TbTestMode, TbMinimumUnbalance, TbMaximumUnbalance, TbMinimumFso, TbMaximumFso,
                TbMaximumCenter, TbFrontBackCornerDifference, TbLeftRightCornerDifference, TbExcessiveCornerValue, TbLeftCornerTrimValue,
                TbBackCornerTrimValue, TbRightCornerTrimValue, TbFrontCornerTrimValue, TbFrontLeftCornerTrimValue, TbBackLeftCornerTrimValue,
                TbBackRightCornerTrimValue, TbFrontRightCornerTrimValue, TbCornersTrimValue, TbAppliedLoad, TbFullLoad, TbFactor,
                TbFsoCorrectionValue
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
    }
}

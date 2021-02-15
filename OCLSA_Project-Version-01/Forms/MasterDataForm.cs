﻿using OCLSA_Project_Version_01.Common;
using OCLSA_Project_Version_01.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Type = OCLSA_Project_Version_01.Models.Type;

namespace OCLSA_Project_Version_01.Forms
{
    public partial class MasterDataForm : Form
    {
        private readonly ApplicationDbContext _context;

        public MasterDataForm()
        {
            InitializeComponent();
            DisableControls();

            btnEdit.Hide();

            _context = new ApplicationDbContext();
        }

        private void tbLoadCellType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Return)) return;

            if (tbLoadCellType.Text == "")
            {
                MessageBox.Show(@"Please Enter the Load Cell Type...");
                return;
            }

            var loadCellTypeInDb = FindLoadCellTypeInDb();

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

                    DisplayLoadCellTypeData(loadCellTypeInDb);
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

            SaveLoadCellTypeDataToDb();

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

            var loadCellTypeExisting = FindExistingLoadCellType();

            if (loadCellTypeExisting == null) return;

            EditLoadCellTypeDataInDb(loadCellTypeExisting);

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

        private void DisplayLoadCellTypeData(Type loadCellTypeInDb)
        {
            tbTestMode.Text = loadCellTypeInDb.TestMode;
            tbMaximumCenter.Text = Convert.ToString(loadCellTypeInDb.MaximumCenterValue, CultureInfo.CurrentCulture);
            tbLeftCornerTrimValue.Text = Convert.ToString(loadCellTypeInDb.LeftCornerTrimValue);
            tbBackCornerTrimValue.Text = Convert.ToString(loadCellTypeInDb.BackCornerTrimValue);
            tbRightCornerTrimValue.Text = Convert.ToString(loadCellTypeInDb.RightCornerTrimValue);
            tbFrontCornerTrimValue.Text = Convert.ToString(loadCellTypeInDb.FrontCornerTrimValue);
            tbFrontLeftCornerTrimValue.Text = Convert.ToString(loadCellTypeInDb.FrontLeftCornerTrimValue);
            tbBackLeftCornerTrimValue.Text = Convert.ToString(loadCellTypeInDb.BackLeftCornerTrimValue);
            tbBackRightCornerTrimValue.Text = Convert.ToString(loadCellTypeInDb.BackRightCornerTrimValue);
            tbFrontRightCornerTrimValue.Text = Convert.ToString(loadCellTypeInDb.FrontRightCornerTrimValue);
            tbCornersTrimValue.Text = Convert.ToString(loadCellTypeInDb.CornerTrimValue);
            tbExcessiveCornerValue.Text = Convert.ToString(loadCellTypeInDb.ExcessiveCornerValue, CultureInfo.CurrentCulture);
            tbFrontBackCornerDifference.Text =
                Convert.ToString(loadCellTypeInDb.FrontBackCornerDifference, CultureInfo.CurrentCulture);
            tbLeftRightCornerDifference.Text =
                Convert.ToString(loadCellTypeInDb.LeftRightCornerDifference, CultureInfo.CurrentCulture);
            tbMinimumUnbalance.Text = Convert.ToString(loadCellTypeInDb.MinimumUnbalanceValue, CultureInfo.CurrentCulture);
            tbMaximumUnbalance.Text = Convert.ToString(loadCellTypeInDb.MaximumUnbalanceValue, CultureInfo.CurrentCulture);
            tbMinimumFso.Text = Convert.ToString(loadCellTypeInDb.MinimumFsoValue, CultureInfo.CurrentCulture);
            tbMaximumFso.Text = Convert.ToString(loadCellTypeInDb.MaximumFsoValue, CultureInfo.CurrentCulture);
            tbAppliedLoad.Text = Convert.ToString(loadCellTypeInDb.AppliedLoad, CultureInfo.CurrentCulture);
            tbFullLoad.Text = Convert.ToString(loadCellTypeInDb.Capacity, CultureInfo.CurrentCulture);
            tbFactor.Text = Convert.ToString(loadCellTypeInDb.Factor, CultureInfo.CurrentCulture);
            tbFsoCorrectionValue.Text = Convert.ToString(loadCellTypeInDb.FsoCorrectionValue, CultureInfo.CurrentCulture);
        }

        private Type FindLoadCellTypeInDb()
        {
            var loadCellTypeInDb = _context.Types.SingleOrDefault(l => l.Name == tbLoadCellType.Text);
            return loadCellTypeInDb;
        }

        private Type FindExistingLoadCellType()
        {
            var loadCellTypeExisting = _context.Types.Find(tbLoadCellType.Text);
            return loadCellTypeExisting;
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

        private void SaveLoadCellTypeDataToDb()
        {
            try
            {
                var loadCellType = new Type
                {
                    Name = RemoveWhitespace(tbLoadCellType.Text),
                    TestMode = RemoveWhitespace(tbTestMode.Text),
                    MaximumCenterValue = Convert.ToDouble(tbMaximumCenter.Text),
                    LeftCornerTrimValue = string.IsNullOrWhiteSpace(tbLeftCornerTrimValue.Text)
                        ? 0d
                        : Convert.ToDouble(tbLeftCornerTrimValue.Text),
                    BackCornerTrimValue = string.IsNullOrWhiteSpace(tbBackCornerTrimValue.Text)
                        ? 0d
                        : Convert.ToDouble(tbBackCornerTrimValue.Text),
                    RightCornerTrimValue = string.IsNullOrWhiteSpace(tbRightCornerTrimValue.Text)
                        ? 0d
                        : Convert.ToDouble(tbRightCornerTrimValue.Text),
                    FrontCornerTrimValue = string.IsNullOrWhiteSpace(tbFrontCornerTrimValue.Text)
                        ? 0d
                        : Convert.ToDouble(tbFrontCornerTrimValue.Text),
                    FrontLeftCornerTrimValue = string.IsNullOrWhiteSpace(tbFrontLeftCornerTrimValue.Text)
                        ? 0d
                        : Convert.ToDouble(tbFrontLeftCornerTrimValue.Text),
                    BackLeftCornerTrimValue = string.IsNullOrWhiteSpace(tbBackLeftCornerTrimValue.Text)
                        ? 0d
                        : Convert.ToDouble(tbBackLeftCornerTrimValue.Text),
                    BackRightCornerTrimValue = string.IsNullOrWhiteSpace(tbBackRightCornerTrimValue.Text)
                        ? 0d
                        : Convert.ToDouble(tbBackRightCornerTrimValue.Text),
                    FrontRightCornerTrimValue = string.IsNullOrWhiteSpace(tbFrontRightCornerTrimValue.Text)
                        ? 0d
                        : Convert.ToDouble(tbFrontRightCornerTrimValue.Text),
                    CornerTrimValue = string.IsNullOrWhiteSpace(tbCornersTrimValue.Text)
                        ? 0d
                        : Convert.ToDouble(tbCornersTrimValue.Text),
                    ExcessiveCornerValue = Convert.ToDouble(tbExcessiveCornerValue.Text),
                    FrontBackCornerDifference = Convert.ToDouble(tbFrontBackCornerDifference.Text),
                    LeftRightCornerDifference = Convert.ToDouble(tbLeftRightCornerDifference.Text),
                    MinimumUnbalanceValue = Convert.ToDouble(tbMinimumUnbalance.Text),
                    MaximumUnbalanceValue = Convert.ToDouble(tbMaximumUnbalance.Text),
                    MinimumFsoValue = Convert.ToDouble(tbMinimumFso.Text),
                    MaximumFsoValue = Convert.ToDouble(tbMaximumFso.Text),
                    AppliedLoad = Convert.ToDouble(tbAppliedLoad.Text),
                    Capacity = Convert.ToDouble(tbFullLoad.Text),
                    Factor = Convert.ToDouble(tbFactor.Text),
                    FsoCorrectionValue = Convert.ToDouble(tbFsoCorrectionValue.Text)
                };

                _context.Types.Add(loadCellType);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void EditLoadCellTypeDataInDb(Type loadCellTypeExisting)
        {
            loadCellTypeExisting.Name = RemoveWhitespace(tbLoadCellType.Text);
            loadCellTypeExisting.TestMode = RemoveWhitespace(tbTestMode.Text);
            loadCellTypeExisting.LeftCornerTrimValue = string.IsNullOrWhiteSpace(tbLeftCornerTrimValue.Text)
                ? 0d
                : Convert.ToDouble(tbLeftCornerTrimValue.Text);
            loadCellTypeExisting.BackCornerTrimValue = string.IsNullOrWhiteSpace(tbBackCornerTrimValue.Text)
                ? 0d
                : Convert.ToDouble(tbBackCornerTrimValue.Text);
            loadCellTypeExisting.RightCornerTrimValue = string.IsNullOrWhiteSpace(tbRightCornerTrimValue.Text)
                ? 0d
                : Convert.ToDouble(tbRightCornerTrimValue.Text);
            loadCellTypeExisting.FrontCornerTrimValue = string.IsNullOrWhiteSpace(tbFrontCornerTrimValue.Text)
                ? 0d
                : Convert.ToDouble(tbFrontCornerTrimValue.Text);
            loadCellTypeExisting.FrontLeftCornerTrimValue = string.IsNullOrWhiteSpace(tbFrontLeftCornerTrimValue.Text)
                ? 0d
                : Convert.ToDouble(tbFrontLeftCornerTrimValue.Text);
            loadCellTypeExisting.BackLeftCornerTrimValue = string.IsNullOrWhiteSpace(tbBackLeftCornerTrimValue.Text)
                ? 0d
                : Convert.ToDouble(tbBackLeftCornerTrimValue.Text);
            loadCellTypeExisting.BackRightCornerTrimValue = string.IsNullOrWhiteSpace(tbBackRightCornerTrimValue.Text)
                ? 0d
                : Convert.ToDouble(tbBackRightCornerTrimValue.Text);
            loadCellTypeExisting.FrontRightCornerTrimValue = string.IsNullOrWhiteSpace(tbFrontRightCornerTrimValue.Text)
                ? 0d
                : Convert.ToDouble(tbFrontRightCornerTrimValue.Text);
            loadCellTypeExisting.CornerTrimValue = string.IsNullOrWhiteSpace(tbCornersTrimValue.Text)
                ? 0d
                : Convert.ToDouble(tbCornersTrimValue.Text);
            loadCellTypeExisting.ExcessiveCornerValue = Convert.ToDouble(tbExcessiveCornerValue.Text);
            loadCellTypeExisting.FrontBackCornerDifference = Convert.ToDouble(tbFrontBackCornerDifference.Text);
            loadCellTypeExisting.LeftRightCornerDifference = Convert.ToDouble(tbLeftRightCornerDifference.Text);
            loadCellTypeExisting.MinimumUnbalanceValue = Convert.ToDouble(tbMinimumUnbalance.Text);
            loadCellTypeExisting.MaximumUnbalanceValue = Convert.ToDouble(tbMaximumUnbalance.Text);
            loadCellTypeExisting.MinimumFsoValue = Convert.ToDouble(tbMinimumFso.Text);
            loadCellTypeExisting.MaximumFsoValue = Convert.ToDouble(tbMaximumFso.Text);
            loadCellTypeExisting.AppliedLoad = Convert.ToDouble(tbAppliedLoad.Text);
            loadCellTypeExisting.Capacity = Convert.ToDouble(tbFullLoad.Text);
            loadCellTypeExisting.Factor = Convert.ToDouble(tbFactor.Text);
            loadCellTypeExisting.FsoCorrectionValue = Convert.ToDouble(tbFsoCorrectionValue.Text);

            _context.SaveChanges();
        }

        private bool CheckAllInputs()
        {
            var textControlsWithOneCorner = new List<Control>
            {
                tbLoadCellType, tbTestMode, tbMinimumUnbalance, tbMaximumUnbalance, tbMinimumFso, tbMaximumFso,
                tbMaximumCenter, tbFrontBackCornerDifference, tbLeftRightCornerDifference, tbExcessiveCornerValue,
                tbCornersTrimValue, tbAppliedLoad, tbFullLoad, tbFactor, tbFsoCorrectionValue
            };

            var textControlsWithAllCorners = new List<Control>
            {
                tbLoadCellType, tbTestMode, tbMinimumUnbalance, tbMaximumUnbalance, tbMinimumFso, tbMaximumFso,
                tbMaximumCenter, tbFrontBackCornerDifference, tbLeftRightCornerDifference, tbExcessiveCornerValue,
                tbLeftCornerTrimValue, tbBackCornerTrimValue, tbRightCornerTrimValue, tbFrontCornerTrimValue,
                tbFrontLeftCornerTrimValue, tbBackLeftCornerTrimValue, tbBackRightCornerTrimValue,
                tbFrontRightCornerTrimValue, tbAppliedLoad, tbFullLoad, tbFactor, tbFsoCorrectionValue
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
                tbTestMode, tbMinimumUnbalance, tbMaximumUnbalance, tbMinimumFso, tbMaximumFso,
                tbMaximumCenter, tbFrontBackCornerDifference, tbLeftRightCornerDifference, tbExcessiveCornerValue, btnSave,
                tbAppliedLoad, tbFullLoad, tbFactor, tbFsoCorrectionValue
            };

            foreach (var input in inputsList)
            {
                input.Enabled = command;
            }
        }

        private void DisableControls()
        {
            tbCornersTrimValue.Enabled = false;
            EnableOrDisableCornerInputs(false);
            EnableOrDisableInputs(false);
            rbSameValue.Enabled = false;
            rbDifferentValues.Enabled = false;
        }

        private static string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }

        private void ClearControls()
        {
            var controls = new List<Control>
            {
                tbLoadCellType, tbTestMode, tbMinimumUnbalance, tbMaximumUnbalance, tbMinimumFso, tbMaximumFso,
                tbMaximumCenter, tbFrontBackCornerDifference, tbLeftRightCornerDifference, tbExcessiveCornerValue, tbLeftCornerTrimValue,
                tbBackCornerTrimValue, tbRightCornerTrimValue, tbFrontCornerTrimValue, tbFrontLeftCornerTrimValue, tbBackLeftCornerTrimValue,
                tbBackRightCornerTrimValue, tbFrontRightCornerTrimValue, tbCornersTrimValue, tbAppliedLoad, tbFullLoad, tbFactor,
                tbFsoCorrectionValue
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
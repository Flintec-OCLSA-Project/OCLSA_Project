using OCLSA_Project_Version_01.Common;
using OCLSA_Project_Version_01.DataAccess.LoginForm;
using OCLSA_Project_Version_01.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OCLSA_Project_Version_01.Forms
{
    public partial class LoginForm : Form
    {
        public readonly ApplicationDbContext Context;
        private DialogResult _result;
        public ImageConvertor ImageConvertor { get; }
        public User User { get; }

        public LoginForm()
        {
            InitializeComponent();

            Context = new ApplicationDbContext();
            ImageConvertor = new ImageConvertor();
            User = new User(this);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            cbStation.Enabled = false;
        }

        private void btnOperatorLogin_Click(object sender, EventArgs e)
        {
            var username = tbUsername.Text;
            var password = tbPassword.Text;

            if (username != "" && password != "")
            {
                var result = User.CheckUserInDb(username);
                var userInDb = result.UserInDb;
                if (result.IsInvalidUser) return;

                var fullName = userInDb.FullName;
                var employeeId = userInDb.EmployeeId;
                var location = userInDb.Location;

                if (userInDb.UserName == username && userInDb.Password == password)
                {
                    switch (userInDb.Administration)
                    {
                        case "OK":
                            if (_result != DialogResult.Yes && _result != DialogResult.No)
                                _result = ResultMessage.Result(
                                    "Select YES to open Master-data Window & NO to open Corner Trimming Window.",
                                    "Choose Option");

                            GetResponseAndDisplay();
                            break;

                        case "NO":
                            if (cbStation.Enabled != true) cbStation.Enabled = true;

                            var image = ImageConvertor.ByteArrayToImage(userInDb.Image);
                            CheckStationAndDisplay(fullName, employeeId, location, image);
                            break;

                        default:
                            MessageBox.Show(@"Administration Status Error...!!!");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show(@"Username or password is wrong...!!!");
                }
            }
            else
            {
                MessageBox.Show(@"Fill all the relevant fields...!!!");
            }
        }

        private void GetResponseAndDisplay()
        {
            if (_result == DialogResult.Yes)
            {
                MessageBox.Show(@"Login is successful...!!! Press OK to open Master-data Window.");
                DisplayForm(new MasterDataForm());
            }
            else
            {
                MessageBox.Show(@"Login is successful...!!! Press OK to open Trimming Window.");
                DisplayForm(new MainForm());
            }
        }

        private void CheckStationAndDisplay(string fullName, int employeeId, string location, Image image)
        {
            if (cbStation.SelectedIndex > -1)
            {
                var station = cbStation.Text;
                MessageBox.Show(@"Login is successful...");
                DisplayForm(new MainForm(fullName, employeeId, location, station, image));
            }
            else
            {
                MessageBox.Show(@"Select the station....");
            }
        }

        private void DisplayForm(Form form)
        {
            Hide();
            form.ShowDialog();
            Close();
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != Convert.ToChar(Keys.Return)) return;

            if (CheckInputFields()) return;

            var username = tbUsername.Text;
            var result = User.CheckUserInDb(username);
            var userInDb = result.UserInDb;
            if (result.IsInvalidUser) return;

            switch (userInDb.Administration)
            {
                case "OK":
                    _result = ResultMessage.Result("Select YES to open Master-data Window & NO to open Corner Trimming Window.", "Choose Option");
                    break;

                case "NO":
                    MessageBox.Show(@"Select the station & Click on Login...!!!");
                    cbStation.Enabled = true;
                    break;

                default:
                    MessageBox.Show(@"Administration status error...!!!");
                    break;
            }
        }

        private bool CheckInputFields()
        {
            if (tbUsername.Text != "" && tbPassword.Text != "") return false;
            MessageBox.Show(@"Fill the fields...!!!");
            return true;
        }
    }
}

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
    public partial class LoginForm : Form
    {
        private readonly ApplicationDbContext _context;
        private DialogResult _result;

        public LoginForm()
        {
            InitializeComponent();

            _context = new ApplicationDbContext();
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
                var result = CheckUserInDb();
                var userInDb = result.UserInDb;
                if (result.IsInvalidUser) return;

                var adminStatus = userInDb.Administration;
                var fullName = userInDb.FullName;
                var employeeId = userInDb.EmployeeId;
                var location = userInDb.Location;

                if (userInDb.UserName == username && userInDb.Password == password)
                {
                    switch (userInDb.Administration)
                    {
                        case "OK":
                            if (_result != DialogResult.Yes && _result != DialogResult.No)
                                _result = Result(
                                    "Select YES to open Master-data Window & NO to open Corner Trimming Window.",
                                    "Choose option");

                            GetResponseAndDisplay();
                            break;

                        case "NO":
                            if (cbStation.Enabled != true) cbStation.Enabled = true;
                            CheckStationAndDisplay(fullName, employeeId, location);
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

        private static DialogResult Result(string message, string title)
        {
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            var result = MessageBox.Show(message, title, buttons);
            return result;
        }

        private void GetResponseAndDisplay()
        {
            if (_result == DialogResult.Yes)
            {
                MessageBox.Show(@"Login is successful...!!!");
                DisplayForm(new MasterDataForm());
            }
            else
            {
                DisplayForm(new MainForm());
            }
        }

        private void CheckStationAndDisplay(string fullName, int employeeId, string location)
        {
            if (cbStation.SelectedIndex > -1)
            {
                var station = cbStation.Text;
                MessageBox.Show(@"Login is successful...");
                DisplayForm(new MainForm(fullName, employeeId, location, station));
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

            var result = CheckUserInDb();
            var userInDb = result.UserInDb;
            if (result.IsInvalidUser) return;

            switch (userInDb.Administration)
            {
                case "OK":
                    _result = Result("Select YES to open Master-data Window & NO to open Corner Trimming Window.", "Choose option");
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

        private CheckUserInDbResult CheckUserInDb()
        {
            var userInDb = _context.Employees.SingleOrDefault(u => u.UserName == tbUsername.Text);

            if (userInDb != null)
            {
                return new CheckUserInDbResult{UserInDb = userInDb, IsInvalidUser = false};
            }

            MessageBox.Show(@"Invalid User. Please Check Username...!!!");

            return new CheckUserInDbResult {UserInDb = null, IsInvalidUser = true};
        }

        private bool CheckInputFields()
        {
            if (tbUsername.Text == "" && tbPassword.Text == "")
            {
                MessageBox.Show(@"Fill the fields...!!!");
                return true;
            }

            return false;
        }
    }

    public class CheckUserInDbResult
    {
        public Employee UserInDb { get; set; }
        public bool IsInvalidUser { get; set; }
    }
}

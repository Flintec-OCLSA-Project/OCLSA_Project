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
        private ApplicationDbContext _context;

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
            var userType = cbUserType.Text;
            var station = cbStation.Text;

            if (username == "" && password == "" && userType == "")
            {
                MessageBox.Show(@"Fill all the relevant fields...!!!");
                return;
            }

            var userInDb = _context.Employees.SingleOrDefault(u => u.UserName == username);

            if (userInDb == null)
            {
                MessageBox.Show(@"Username is invalid...!!!");
                return;
            }



           

        }
    }
}

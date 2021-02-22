using System.Linq;
using System.Windows.Forms;

namespace OCLSA_Project_Version_01.DataAccess.LoginForm
{
    public class User
    {
        private Forms.LoginForm _loginForm;

        public User(Forms.LoginForm loginForm)
        {
            _loginForm = loginForm;
        }

        public CheckUserInDbResult CheckUserInDb(string username)
        {
            var userInDb = _loginForm.Context.Employees.SingleOrDefault(u => u.UserName == username);

            if (userInDb != null)
            {
                return new CheckUserInDbResult { UserInDb = userInDb, IsInvalidUser = false };
            }

            MessageBox.Show(@"Invalid User. Please Check Username...!!!");

            return new CheckUserInDbResult { UserInDb = null, IsInvalidUser = true };
        }
    }
}
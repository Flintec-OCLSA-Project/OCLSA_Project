using OCLSA_Project_Version_01.Models;

namespace OCLSA_Project_Version_01.DataAccess.LoginForm
{
    public class CheckUserInDbResult
    {
        public Employee UserInDb { get; set; }
        public bool IsInvalidUser { get; set; }
    }
}
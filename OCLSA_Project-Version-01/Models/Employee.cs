using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCLSA_Project_Version_01.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool Administration { get; set; }

        [Required]
        public string FullName { get; set; }

        public byte[] Image { get; set; }

        [Required]
        public string Location { get; set; }

    }
}

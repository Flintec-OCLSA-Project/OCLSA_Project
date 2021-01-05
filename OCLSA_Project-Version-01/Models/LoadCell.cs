using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCLSA_Project_Version_01.Models
{
    public class LoadCell
    {
        public int Id { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        public Type Type { get; set; }

        [Required]
        public byte TypeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCLSA_Project_Version_01.Models
{
    public class Type
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TestMode { get; set; }

        [Required]
        public double MaximumCenterReading { get; set; }

        public double? FrontCorner { get; set; }
        public double? BackCorner{ get; set; }
        public double? LeftCorner{ get; set; }
        public double? RightCorner{ get; set; }
        public double? DiagonalFrontRightCorner{ get; set; }
        public double? DiagonalFrontLeftCorner { get; set; }
        public double? DiagonalBackRightCorner { get; set; }
        public double? DiagonalBackLeftCorner  { get; set; }

        [Required]
        public double MaximumUnbalanceReading { get; set; }

        [Required]
        public double MinimumUnbalanceReading { get; set; }

        [Required]
        public double MaximumFsoReading { get; set; }

        [Required]
        public double MinimumFsoReading { get; set; }

    }
}

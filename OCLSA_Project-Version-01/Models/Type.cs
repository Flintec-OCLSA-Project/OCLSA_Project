using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCLSA_Project_Version_01.Models
{
    public class Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }

        [Required]
        public string TestMode { get; set; }

        [Required]
        public double MaximumCenterValue { get; set; }

        public double? FrontCornerTrimValue { get; set; }
        public double? BackCornerTrimValue { get; set; }
        public double? LeftCornerTrimValue { get; set; }
        public double? RightCornerTrimValue { get; set; }
        public double? FrontRightCornerTrimValue { get; set; }
        public double? FrontLeftCornerTrimValue { get; set; }
        public double? BackRightCornerTrimValue { get; set; }
        public double? BackLeftCornerTrimValue { get; set; }
        public double? CornerTrimValue { get; set; }

        [Required]
        public double ExcessiveCornerValue { get; set; }

        [Required]
        public double LeftRightCornerDifference { get; set; }

        [Required]
        public double FrontBackCornerDifference { get; set; }

        [Required]
        public double MaximumUnbalanceValue { get; set; }

        [Required]
        public double MinimumUnbalanceValue { get; set; }

        [Required]
        public double MaximumFsoValue { get; set; }

        [Required]
        public double MinimumFsoValue { get; set; }

        [Required]
        public double AppliedLoad { get; set; }

        [Required]
        public double Capacity { get; set; }

        [Required]
        public double Factor { get; set; }
        
        [Required]
        public double FsoCorrectionValue { get; set; }
    }
}

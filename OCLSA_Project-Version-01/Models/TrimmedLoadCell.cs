using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OCLSA_Project_Version_01.Models
{
    public class TrimmedLoadCell
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SerialNumber { get; set; }

        [Required]
        public string LoadCellType { get; set; }

        [Required]
        public DateTime StartingTime { get; set; }

        [Required]
        public DateTime EndingTime { get; set; }

        [Required]
        public double BridgeUnbalance { get; set; }

        [Required]
        public double InitialFso { get; set; }

        [Required]
        public double InitialLeftCorner { get; set; }

        [Required]
        public double InitialD1Corner { get; set; }

        [Required]
        public double InitialBackCorner { get; set; }

        [Required]
        public double InitialD2Corner { get; set; }

        [Required]
        public double InitialRightCorner { get; set; }

        [Required]
        public double InitialD3Corner { get; set; }

        [Required]
        public double InitialFrontCorner { get; set; }

        [Required]
        public double InitialD4Corner { get; set; }

        [Required]
        public double FinalLeftCorner { get; set; }

        [Required]
        public double FinalD1Corner { get; set; }

        [Required]
        public double FinalBackCorner { get; set; }

        [Required]
        public double FinalD2Corner { get; set; }

        [Required]
        public double FinalRightCorner { get; set; }

        [Required]
        public double FinalD3Corner { get; set; }

        [Required]
        public double FinalFrontCorner { get; set; }

        [Required]
        public double FinalD4Corner { get; set; }

        [Required]
        public double CalculatedFso { get; set; }

        [Required]
        public double FinalFso { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string RejectCriteria { get; set; }

        [Required]
        public int TrimCount { get; set; }

        [Required]
        public string Operator { get; set; }

        [Required]
        public int OperatorId { get; set; }

        [Required]
        public int NoOfResistors { get; set; }

        [Required]
        public bool IsFsoCorrectionAvailable { get; set; }

        [Required]
        public string TotalTime { get; set; }

        [Required]
        public int NoOfTestRuns { get; set; }
    }
}

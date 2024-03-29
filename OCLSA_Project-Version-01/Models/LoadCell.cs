﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCLSA_Project_Version_01.Models
{
    public class LoadCell
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SerialNumber { get; set; }

        [ForeignKey("Type")]
        public string TypeName { get; set; }

        public Type Type { get; set; }

        [Required]
        public string MetalCategory { get; set; }

    }
}

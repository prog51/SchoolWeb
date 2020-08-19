﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class SchoolVM
    {
       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Parish { get; set; }

        [Required]
        [Display(Name="School Pass Mark")]
        public int PassMark { get; set; }

        public DateTime DateCreated { get; set; }
    }

    public class CreateSchoolVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }


        [Required]
        public string Address { get; set; }

        [Required]
        public string Parish { get; set; }

        [Required]
        [Display(Name = "School Pass Mark")]
        public int PassMark { get; set; }
    }
}

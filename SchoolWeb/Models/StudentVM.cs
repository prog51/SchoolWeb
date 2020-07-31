﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class StudentVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public double Score { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

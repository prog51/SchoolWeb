using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [ForeignKey("OrganizationID")]
        public Organization Organization { get; set; }

        public string OrganizationID { get; set; }

        [Required]
        public double Score { get; set; }

        [Required]
        public string Address { get; set; }

        public string Parish { get; set; }

        [Required]
        public string Email { get; set; }

        public string Placed { get; set; }

        public DateTime DateCreated { get; set; }

        public string SchoolPlaced { get; set; }
    }
}

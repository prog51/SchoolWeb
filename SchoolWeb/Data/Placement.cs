using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Data
{
    public class Placement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("OrganID")]
        public Organization Organ { get; set; }

        public string OrganID { get; set; }

        [ForeignKey("StudentID")]
        public Student Student { get; set; }

        public int StudentID { get; set; }

        [ForeignKey("SchoolID")]
        public School School { get; set; }

        public int SchoolID { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

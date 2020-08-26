using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Data
{
    public class School
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey("OrganizationID")]
        public Organization Organization { get; set; }

        public string OrganizationID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Parish { get; set; }

        [Required]
        public int PassMark { get; set; }

        [ForeignKey("RankID")]
        public Rank Rank { get; set; }

        public int RankID { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

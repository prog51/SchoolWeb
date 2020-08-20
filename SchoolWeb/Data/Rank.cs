using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Data
{
    public class Rank
    {
        [Key]
        public int Id { get; set; }
             
        [ForeignKey("OrganizationID")]
        public Organization Organization { get; set; }

        public string OrganizationID { get; set; }

        [Required]
        public string ValueRank { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

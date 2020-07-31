using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class RankVM
    {
        public int Id { get; set; }

        public SchoolVM School { get; set; }

        public int SchoolID { get; set; }

        public OrganizationVM Organization { get; set; }

        public string OrganizationID { get; set; }

        [Required]
        public string Value { get; set; }

        public DateTime DateCreated { get; set; }
    }
}

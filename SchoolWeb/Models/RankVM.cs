using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class RankVM
    {
      
        public int Id { get; set; }

        [Required]
        [ForeignKey("SchoolID")]
        public SchoolVM School { get; set; }

        public int SchoolID { get; set; }
        
        [Required]
        [ForeignKey("OrganizationID")]
        public OrganizationVM Organization { get; set; }

        public string OrganizationID { get; set; }

        public IEnumerable<SelectListItem> Schools { get; set; }

        public IEnumerable<SelectListItem> Organizations { get; set; }

        public string Value { get; set; }

        public DateTime DateCreated { get; set; }
    }


    public class CreateRankVM
    {
        public IEnumerable<SelectListItem> Organizations { get; set; }
        public List<OrganizationVM> OrganizationList { get; set; }

        public IEnumerable<SelectListItem> Schools { get; set; }
        public List<SchoolVM> SchoolList { get; set; }

        public string Value { get; set; }
    }
}

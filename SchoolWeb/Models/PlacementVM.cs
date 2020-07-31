using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class PlacementVM
    {
        public int Id { get; set; }
        
        public OrganizationVM Organ { get; set; }

        public string OrganID { get; set; }
        
        public StudentVM Student { get; set; }

        public int StudentID { get; set; }
        
        public SchoolVM School { get; set; }

        public int SchoolID { get; set; }

        public IEnumerable<SelectListItem> Organizations { get; set; }

        public IEnumerable<SelectListItem> Students { get; set; }

        public IEnumerable<SelectListItem> Schools { get; set; }

        public DateTime DateCreated { get; set; }

        
    }
}

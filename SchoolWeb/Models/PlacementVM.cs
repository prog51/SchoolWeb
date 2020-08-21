using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolWeb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class PlacementVM
    {

        
        public Organization Organ { get; set; }
             
        public string OrganID { get; set; }

        public StudentVM Student { get; set; }
           
        public int StudentID { get; set; }
        
        public SchoolVM School { get; set; }

        public int SchoolID { get; set; }

        public DateTime DateCreated { get; set; }

     }

    public class CreatePlacementVM
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

            public IEnumerable<SelectListItem> School { get; set; }

            public IEnumerable<SelectListItem> Student { get; set; }
    }
}

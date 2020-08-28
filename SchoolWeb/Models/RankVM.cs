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

        public OrganizationVM Organization { get; set; }

        public string OrganizationID { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Rank Tag")]
        public string ValueRank { get; set; }

    }


    public class CreateRankVM
    {
     
   
     [Display(Name = "Rank value")]
     public string ValueRank { get; set; }

     [Required]
     [Display(Name = "Provide description of rank value")]
     public string Description { get; set; }     

    }
}

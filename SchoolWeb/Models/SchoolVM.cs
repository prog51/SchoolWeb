using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class SchoolVM
    {
       
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Parish { get; set; }

        [Required]
        [Display(Name="School Pass Mark")]
        public int PassMark { get; set; }

        [Required]
        [Display(Name = "School Rank")]
        public RankVM Rank { get; set; }

        public int RankId { get; set; }

        public DateTime DateCreated { get; set; }
    }

    public class CreateSchoolVM
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

        public IEnumerable<SelectListItem> Ranks { get; set; }

        [Display(Name = "Rank")]
        public int RankId { get; set; }

        [Required]
        [Display(Name = "School Pass Mark")]
        public int PassMark { get; set; }
    }

    public class DisplaySchoolVM
    {
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

        public List<SchoolVM> Rank { get; set; }

    }

    public class EditSchoolVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Parish { get; set; }

        [Required]
        [Display(Name = "School Pass Mark")]
        public int PassMark { get; set; }

        [Required]
        [Display(Name = "School Rank")]
        public RankVM Rank { get; set; }

        public IEnumerable<SelectListItem> Ranks { get; set; }

        public int RankId { get; set; }

    }
}

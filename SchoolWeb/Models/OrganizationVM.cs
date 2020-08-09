using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Models
{
    public class OrganizationVM
    {

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string OrgName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Location { get; set; }

        public DateTime DateSignedUp { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWeb.Data
{
    public class Organization : IdentityUser
    {

        [Required]
        public string OrgName { get; set; }

        [Required]
        public string Location { get; set; }

        public DateTime DateSignedUp { get; set; }
    }
}

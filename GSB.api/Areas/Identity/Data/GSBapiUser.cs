using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GSB.Shared.Models;
using Microsoft.AspNetCore.Identity;

namespace GSB.api.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the GSBapiUser class
    public class GSBapiUser : IdentityUser
    {
        [Key]
        public int VisiteurId { get; set; }
        public Visiteur Visiteur { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}

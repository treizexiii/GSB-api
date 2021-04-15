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
        [Required]
        public override string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Visiteur Visiteur { get; set; }
        [Key]
        public int VisiteurId { get; set; }
    }
}

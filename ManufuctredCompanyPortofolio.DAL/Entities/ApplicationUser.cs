using ManufuctredCompanyPortofolio.DAL.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufuctredCompanyPortofolio.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public bool IsAgree { get; set; }
    }
}

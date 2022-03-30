namespace Card_Sanctum.Infrastructure.Data.Identity
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? PatronymicName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }
    }
}

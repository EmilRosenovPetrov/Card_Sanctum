namespace Card_Sanctum.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserRolesViewModel
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string[] RoleNames { get; set; }
    }
}

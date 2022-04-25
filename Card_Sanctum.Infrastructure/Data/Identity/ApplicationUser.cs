namespace Card_Sanctum.Infrastructure.Data.Identity
{
    using Card_Sanctum.Infrastructure.Data.Common;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
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

        [Range(0, UserConstants.MaxLifeTotal)]
        public int LifePints { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        [Range(0, (double)UserConstants.MaxUserBudget)]
        public decimal Budget { get; set; } = 999;

        public ICollection<Card>? Cards { get; set; } = new List<Card>();

        public ICollection<Deck>? Decks { get; set; } = new List<Deck>();

    }
}

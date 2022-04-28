namespace Card_Sanctum.Infrastructure.Data
{
    using Card_Sanctum.Infrastructure.Data.Identity;
    using Card_Sanctum.Infrastructure.Data.Migrations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Card
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        [Range(0, 1000)]
        public int? Quantity { get; set; }

        [Range(0, 100)]
        public int? Attack { get; set; }

        [Range(0, 100)]
        public int? Defense { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 6)]
        public Rarety Rarety { get; set; }

        [Required]
        [Range(0, 10)]
        public CardType CardType { get; set; }

        [Required]
        [Range(0, 10)]
        public Color Color { get; set; }


        public ICollection<Deck>? Decks { get; set; } = new List<Deck>();

        public ICollection<BoosterPack>? BoosterPackCards { get; set; } = new List<BoosterPack>();

        public ICollection<ApplicationUser>? Users { get; set; } = new List<ApplicationUser>();

        [StringLength(450)]
        public Guid? HobbyShopId { get; set; }

        [ForeignKey(nameof(HobbyShopId))]
        public HobbyShop? HobbyShop { get; set; }

        
    }
}

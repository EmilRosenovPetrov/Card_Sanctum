namespace Card_Sanctum.Infrastructure.Data
{
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

        //Not implemented yet. Maybe needed for booster pack relation.

       // [Required]
       // [StringLength(50)]
       // public string CardCode { get; set; }

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

        [StringLength(450)]
        public Guid? DeckId { get; set; }

        [ForeignKey(nameof(DeckId))]
        public Deck? Deck { get; set; }

        [StringLength(450)]
        public Guid? BoosterPackId { get; set; }

        [ForeignKey(nameof(BoosterPackId))]
        public BoosterPack? BoosterPack { get; set; }

        [StringLength(450)]
        public Guid? HobbyShopId { get; set; }

        [ForeignKey(nameof(HobbyShopId))]
        public HobbyShop? HobbyShop { get; set; }
    }
}

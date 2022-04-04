namespace Card_Sanctum.Infrastructure.Data
{
    using Card_Sanctum.Infrastructure.Data.Common.Repository;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class HobbyShop
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string? Addres { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        [Range(0, (double)HobbyShopConstants.HobbyShopMaxBudget)]
        public decimal Budget { get; set; }

        public ICollection<Trade> Trades { get; set; } = new List<Trade>();

        public IList<Card> HobbyShopCards = new List<Card>();
    }
}

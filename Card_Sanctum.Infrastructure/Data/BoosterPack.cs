namespace Card_Sanctum.Infrastructure.Data
{
    using Card_Sanctum.Infrastructure.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BoosterPack
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public string? Edition { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal BoosterPrice { get; set; }

        public ICollection<Card> BoosterCards = new List<Card>();

        [Required]
        [Range(0, BoosterAndCardConstants.BoosterCardCount)]
        public int CardCount { get; set; }

        
        [Required]
        public Trade Trade { get; set; }
       

    }
}

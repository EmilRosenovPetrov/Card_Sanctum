namespace Card_Sanctum.Infrastructure.Data
{
    using Card_Sanctum.Infrastructure.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BoosterPack
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public string? Edition { get; set; }

        public IList<Card> BoosterCards;

        [Required]
        [Range(0, BoosterAndCardConstants.BoosterCardCount)]
        public int CardCount { get; set; }

        public BoosterPack()
        {
            BoosterCards = new List<Card>();
        }

    }
}

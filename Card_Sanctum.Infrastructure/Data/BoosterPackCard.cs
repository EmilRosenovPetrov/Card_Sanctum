namespace Card_Sanctum.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BoosterPackCard
    {
        [Required]
        public Guid? CardId { get; set; }
        [ForeignKey(nameof(CardId))]
        public Card? Card { get; set; }

        [Required]
        public Guid? BoosterPackId { get; set; }
        [ForeignKey(nameof(BoosterPackId))]
        public BoosterPack? BoosterPack { get; set; }
    }
}

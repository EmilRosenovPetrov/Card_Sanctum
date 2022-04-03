namespace Card_Sanctum.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Trade
    {
        [Required]
        public Guid HobbyShopId { get; set; }

        [Required]
        [ForeignKey(nameof(HobbyShopId))]
        public HobbyShop HobbyShop { get; set; }

        [Required]
        public Guid BoosterPackId { get; set; }

        [Required]
        [ForeignKey(nameof(BoosterPackId))]
        public BoosterPack BoosterPak { get; set; }
    }
}

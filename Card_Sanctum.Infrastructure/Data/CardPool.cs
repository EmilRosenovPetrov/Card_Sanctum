namespace Card_Sanctum.Infrastructure.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CardPool
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int CardCount { get; set; }

        public Guid CardId { get; set; }

        [ForeignKey(nameof(CardId))]
        public Card Card { get; set; } 
    }
}

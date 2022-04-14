namespace Card_Sanctum.Core.Models
{
    using Card_Sanctum.Infrastructure.Data;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CardEditViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(200)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "Quantity")]
        public int? Quantity { get; set; }

        [Range(0, 100)]
        [Display(Name = "Attack")]
        public int? Attack { get; set; }

        [Range(0, 100)]
        [Display(Name = "Defense")]
        public int? Defense { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Range(10, 1000)]
        public decimal Price { get; set; }

        [Required]
        [EnumDataType(typeof(Rarety), ErrorMessage = "Rarety must be Common, Uncommon, Rare or Legendary")]
        [Display(Name = "Rarety")]
        public string? Rarety { get; set; }

        [Required]
        [EnumDataType(typeof(CardType), ErrorMessage = "Card type must be land, creature, sorcery, instant, enchantment, planeswalker or commander")]
        [Display(Name = "Type")]
        public string? CardType { get; set; }

        [Required]
        [EnumDataType(typeof(Color), ErrorMessage = "Color must be Black, White, Red, Green or Blue")]
        [Display(Name = "Color")]
        public string? Color { get; set; }
    }
}

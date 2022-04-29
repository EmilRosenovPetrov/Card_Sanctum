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
        [RegularExpression("^(([A-za-zА-яа-я]+[\\s]{1}[A-za-zА-яа-я]+)|([A-Za-zА-яа-я]+))$", ErrorMessage = "Name must include only letters and numbers!")]
        public string Name { get; set; }

        [StringLength(200)]
        [Display(Name = "Description")]
        [RegularExpression("^(([A-za-zА-яа-я]+[\\s]{1}[A-za-zА-яа-я]+)|([A-Za-zА-яа-я]+))$", ErrorMessage = "Description must include only letters and numbers!")]
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
        [Range(0, 1000)]
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

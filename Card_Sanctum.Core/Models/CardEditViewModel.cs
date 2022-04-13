namespace Card_Sanctum.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CardEditViewModel
    {
        public string? Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [StringLength(200)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required]
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
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Rarety")]
        public string? Rarety { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string? CardType { get; set; }

        [Required]
        [Display(Name = "Color")]
        public string? Color { get; set; }
    }
}

namespace Card_Sanctum.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CreateDeckViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("^(([A-za-zА-яа-я]+[\\s]{1}[A-za-zА-яа-я]+)|([A-Za-zА-яа-я]+))$", ErrorMessage = "Name must include only letters and numbers!")]
        public string Name { get; set; }

        [StringLength(500)]
        [RegularExpression("^(([A-za-zА-яа-я]+[\\s]{1}[A-za-zА-яа-я]+)|([A-Za-zА-яа-я]+))$", ErrorMessage = "Description must include only letters and numbers!")]
        public string? Description { get; set; }

        public string? UserId { get; set; }

        public ICollection<CardListViewModel>? Cards { get; set; }
    }
}

namespace Card_Sanctum.Core.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserEditViewModel
    {
        public string? Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression("^(([A-za-zА-яа-я]+[\\s]{1}[A-za-zА-яа-я]+)|([A-Za-zА-яа-я]+))$", ErrorMessage = "Name must include only letters and numbers!")]
        public string? FirstName { get; set; }


        [Required]
        [Display(Name = "Patronimic Name")]
        [RegularExpression("^(([A-za-zА-яа-я]+[\\s]{1}[A-za-zА-яа-я]+)|([A-Za-zА-яа-я]+))$", ErrorMessage = "Name must include only letters and numbers!")]
        public string? PatronimicName { get; set; }


        [Required]
        [RegularExpression("^(([A-za-zА-яа-я]+[\\s]{1}[A-za-zА-яа-я]+)|([A-Za-zА-яа-я]+))$", ErrorMessage = "Name must include only letters and numbers!")]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Budget")]
        [RegularExpression(@"^\d+(\.\d)?$", ErrorMessage = "It cannot have more than one decimal point value")]
        [Range(0.1, 999.99)]
        public decimal? Budget { get; set; }

        
    }
}

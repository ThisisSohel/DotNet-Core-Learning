using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Models
{
    public class Person
    {

        [Required (ErrorMessage ="Name can't be empty")]
        [MaxLength(10, ErrorMessage = "Name length can be more than 10")]
        [MinLength(3, ErrorMessage = "Name length can be less than 3")]
        public string? PersonName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
        [Required]
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Name: {PersonName} - Email: {Email} - Phone: {Phone} - Password {Password} - ConfirmPassword: {ConfirmPassword} - Price {Price}";
        }
    }
}

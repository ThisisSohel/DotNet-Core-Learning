using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.CustomValidation
{
    public class NationalityValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string nationality = (string)value;

            if (!string.IsNullOrEmpty(nationality))
            {
                if(nationality.Length <= 3 || nationality.Length > 20)
                {
                    return new ValidationResult("Nationality length can not be less than 3 or greater than 20");
                }
            }
            return null;
        }
    }
}

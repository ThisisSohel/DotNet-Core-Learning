using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationExample.CustomValidation
{
    public class DateRangeValidator : ValidationAttribute
    {
        public string OtherPropertyName { get; set; }

        /// <summary>
        /// Default Constuctor
        /// </summary>
        public DateRangeValidator() 
        { 
        }

        /// <summary>
        /// Constructor with optional parameters for otherPropertyName.
        /// </summary>
        /// <param name="otherPropertyName"></param>
        public DateRangeValidator(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && value is DateTime toDate)
            {
                // Get the property info of the other date (FromDate)
                var otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

                if (otherProperty == null)
                {
                    return new ValidationResult($"Property '{OtherPropertyName}' not found.");
                }

                // Get the value of the other property
                var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance);

                if (otherPropertyValue != null && otherPropertyValue is DateTime fromDate)
                {
                    if (toDate < fromDate)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}

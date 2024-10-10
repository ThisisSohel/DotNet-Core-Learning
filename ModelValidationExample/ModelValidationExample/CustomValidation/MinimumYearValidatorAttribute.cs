using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.CustomValidation
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; }
        public int MaximumYear { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MinimumYearValidatorAttribute()
        {
        }

        /// <summary>
        /// Constructor with optional parameters for both minimum and maximum year.
        /// </summary>
        /// <param name="minimumYear">Minimum year.</param>
        /// <param name="maximumYear">Maximum year.</param>
        public MinimumYearValidatorAttribute(int minimumYear, int maximumYear)
        {
            MinimumYear = minimumYear;
            MaximumYear = maximumYear;
        }

        /// <summary>
        /// Override the IsValid method to check if the date is within the specified range.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A ValidationResult indicating whether validation succeeded or failed.</returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is DateTime date) // Check if value is a DateTime
                {
                    // Check if the year is within the specified range
                    if (date.Year < MinimumYear || date.Year > MaximumYear)
                    {
                        // If the year is outside the range, return an error message
                        return new ValidationResult(GetErrorMessage());
                    }
                    else
                    {
                        // Validation passed
                        return ValidationResult.Success;
                    }
                }
                else
                {
                    // If value is not a DateTime object, return an error
                    return new ValidationResult("Invalid date format");
                }
            }

            return ValidationResult.Success; // Null value means validation passed (can add additional checks if required)
        }

        /// <summary>
        /// Returns a custom error message based on the range.
        /// </summary>
        /// <returns>A custom error message string.</returns>
        private string GetErrorMessage()
        {
            return $"The year must be between {MinimumYear} and {MaximumYear}.";
        }
    }
}

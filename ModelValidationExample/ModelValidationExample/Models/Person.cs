﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelValidationExample.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Models
{
    public class Person
    {

        [Required(ErrorMessage = "{0} can't be empty")]
        [Display(Name = "Person Name")]
        [RegularExpression("^[A-Za-z .]$", ErrorMessage = "{0} is not in correct format!")]
        //[MaxLength(10, ErrorMessage = "{0} length can be more than 10")]
        //[MinLength(3, ErrorMessage = "{0} length can be less than 3")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} can be more than {1} and less than {2}")]
        public string? PersonName { get; set; }

        [EmailAddress(ErrorMessage = "{0} is not in correct format!")]
        //[BindNever]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "{0} is not in correct format")]
        [ValidateNever] //It is mean this field will be validate!
        public string? Phone { get; set; }
        [Required(ErrorMessage = "{0} can not be blank!")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "{0} can not be blank")]
        [Compare("Password", ErrorMessage = "{1} and {0} are not matched!")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.9, ErrorMessage ="{0} can not be more than {2} and less than {1}")]
        public double? Price { get; set; }

        [MinimumYearValidatorAttribute(2000, 2019, ErrorMessage = "Hello Error from dob")]
        [BindNever]
        public DateTime DateOfBirth { get; set; }

        [NationalityValidatorAttribute (ErrorMessage ="Hello error from Nationality!")]
        public string? Nationality { get; set; }

        public DateTime FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "From_date can not be older than to_date!")]
        public DateTime ToDate { get; set; }

        public List<string?> Tags { get; set; } = new List<string?>();
         public override string ToString()
        {
            return $"Name: {PersonName} - Email: {Email} - Phone: {Phone} - Password {Password} - ConfirmPassword: {ConfirmPassword} - Price {Price}";
        }
    }
}

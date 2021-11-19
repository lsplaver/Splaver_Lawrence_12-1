using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TripsLogUpdated.Models.Validation
{
    public class CustomEmailFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is Regex)
            {
                string stringToCheck = value.ToString();
                bool isCorrectFormat = false;
                isCorrectFormat = Regex.IsMatch(stringToCheck, "^*" + Regex.Escape("@") + "*" + Regex.Escape(".") + "*");
                if (isCorrectFormat)
                {
                    return ValidationResult.Success;
                }
            }
            string message = base.ErrorMessage ?? $"{validationContext.DisplayName} must be in the format of 'name@example.com'";
            return new ValidationResult(message);
        }
    }
}

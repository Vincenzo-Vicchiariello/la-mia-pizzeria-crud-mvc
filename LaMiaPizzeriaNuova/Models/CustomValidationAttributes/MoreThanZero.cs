using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeriaNuova.Models.CustomValidationAttributes
{
    public class MoreThanZero : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            int fieldValue = Convert.ToInt32(value);

            if (fieldValue <= 0)
            {
                return new ValidationResult("Il prezzo non può essere 0");
            }

            return ValidationResult.Success;
        }
    }
}
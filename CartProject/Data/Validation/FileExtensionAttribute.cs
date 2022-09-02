using System.ComponentModel.DataAnnotations;

namespace CartProject.Data.Validation
{
    //This will check for extensions. 
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                string[] extensions = { "jpg", "png" };
                bool result = extensions.Any(x => extension.EndsWith(x));

                if (!result)
                {
                    return new ValidationResult("Only jpg and png are allowed");
                }
            }


            return ValidationResult.Success;
        }
    }
}

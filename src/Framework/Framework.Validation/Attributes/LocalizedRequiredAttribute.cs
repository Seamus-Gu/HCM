using System.ComponentModel.DataAnnotations;

namespace Framework.Validation
{
    public class LocalizedRequiredAttribute : RequiredAttribute, IValidationCodeProvider
    {
        public ValidationErrorEnum Error { get; } = ValidationErrorEnum.Required;

        public LocalizedRequiredAttribute()
        {
            this.ErrorMessageResourceType = typeof(ValidationResource);
            this.ErrorMessageResourceName = nameof(ValidationResource.Required);
        }

        public LocalizedRequiredAttribute(string resourceName)
        {
            this.ErrorMessageResourceType = typeof(ValidationResource);
            this.ErrorMessageResourceName = resourceName;
        }
    }
}
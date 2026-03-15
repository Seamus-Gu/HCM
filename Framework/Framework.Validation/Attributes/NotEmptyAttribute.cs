using Seed.Framework.Core;
using System.ComponentModel.DataAnnotations;

namespace Seed.Framework.Validation
{
    public class NotEmptyAttribute : RequiredAttribute
    {
        public NotEmptyAttribute()
        {
            ErrorMessage = ValidationLocalization.Required;
        }
    }
}
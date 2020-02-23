using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LWarp.ClientApi.Models
{
    public class LinkData : IValidatableObject
    {
        public string LinkValue { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(this.LinkValue))
            {
                yield return new ValidationResult("The link value cannot be empty or only whitespaces", new List<string>() { nameof(this.LinkValue) });
            }
            else if (this.LinkValue.Length <= 3)
            {
                yield return new ValidationResult("Link must be at least 4 characters", new List<string>() { nameof(this.LinkValue) });
            }
        }
    }
}
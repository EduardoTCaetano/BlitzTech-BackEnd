using System.ComponentModel.DataAnnotations;
using BlitzTech.Domain.Entities;
using BlitzTech.Domain.Validations;

namespace BlitzTech.Model
{
    public sealed class Category : EntityBase
    {
        public string Description { get; private set; }
        public bool IsActive { get; private set; }

        public Category(string description, bool isActive)
        {
            ValidateDescription(description);

            Description = description;
            IsActive = isActive;
        }
        public void ValidateDescription(string description)
        {
            DomainExceptionValidations.ExceptionHandler(string.IsNullOrEmpty(description),
           "Invalid Description. Description is required!");
        }

        public void ValidateActive(string isActive)
        {
            DomainExceptionValidations.ExceptionHandler(bool.Parse(isActive),
            "Invalid Active. IsActive is required!");
        }
    }
}
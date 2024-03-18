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
            Description = description;
            IsActive = isActive;
        }
        public void ValidateDomain(string description)
        {
            DomainExceptionValidations.ExceptionHandler(string.IsNullOrEmpty(description),
            "Invalid Description. Description is required!");
        }
        public Category(string description)
        {
            ValidateDomain(description);
        }
    }
}
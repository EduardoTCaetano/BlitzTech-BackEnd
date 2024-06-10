namespace BlitzTech.Domain.Dtos.Category
{
    public class CategoryDto
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public CategoryDto(string description, bool isActive)
        {
            Description = description;
            IsActive = isActive;
        }


    }
}

using BlitzTech.Domain.Dtos.Category;
using BlitzTech.Model;

namespace BlitzTech.Data.Mapping
{
    public static class AutoMapperProfiles
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto(
                category.Description,
                category.IsActive
            );
        }

        public static Category ToCategoryFromCreateDTO(this CreateCategoryRequestDto categoryDto)
        {
            return new Category
            (
                categoryDto.Description,
                categoryDto.IsActive
            );
        }

    }
}

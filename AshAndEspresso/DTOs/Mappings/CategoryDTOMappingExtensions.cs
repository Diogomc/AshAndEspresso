using AshAndEspresso.DTOs.Entities;
using AshAndEspresso.Models;

namespace AshAndEspresso.DTOs.Mappings;

public static class CategoryDTOMappingExtensions
{
    public static CategoryDTO? ToCategoryDTO(this Category category)
    {
        if (category is null) return null;

        return new CategoryDTO
        {
            CategoryId = category.CategoryId,
            Name = category.Name,
            Description = category.Description
        };

    }
    public static Category? ToCategory(this CategoryDTO categoryDto)
    {
        if (categoryDto is null) return null;

        return new Category
        {
            CategoryId = categoryDto.CategoryId,
            Name = categoryDto.Name,
            Description = categoryDto.Description
        };
    }

    public static IEnumerable<CategoryDTO>? ToCategoryDTOList(this IEnumerable<Category> categories)
    {
        if (categories is null || !categories.Any()) 
        {
            return new List<CategoryDTO>();
        };

        return categories.Select(category => new CategoryDTO
        {
            CategoryId = category.CategoryId,
            Name = category.Name,
            Description = category.Description
        }).ToList();


    }
}

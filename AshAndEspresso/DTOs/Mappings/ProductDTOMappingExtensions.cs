using AshAndEspresso.DTOs.Entities;
using AshAndEspresso.Models;

namespace AshAndEspresso.DTOs.Mappings;

public static class ProductDTOMappingExtensions
{
    public static ProductDTO? ToProductDTO(this ProductDTO productDto)
    {
        if (productDto is null) return null;

        return new ProductDTO
        {
            ProductId = productDto.ProductId,
            Name = productDto.Name,
            Description = productDto.Description,
            AvailableQuantity = productDto.AvailableQuantity,
            ImageUrl = productDto.ImageUrl,
            Price = productDto.Price
        };
    }
    public static Product? ToProduct(this ProductDTO productDto)
    {
        if (productDto is null) return null;

        return new Product
        {
            ProductId = productDto.ProductId,
            Name = productDto.Name,
            Description = productDto.Description,
            AvailableQuantity = productDto.AvailableQuantity,
            ImageUrl = productDto.ImageUrl,
            Price = productDto.Price
        };
    }
    public static IEnumerable<ProductDTO>? ToProductDTOList(this IEnumerable<Product> products)
    {
        if (products is null) return null;

        return products.Select(productDto => new ProductDTO
        {
            ProductId = productDto.ProductId,
            Name = productDto.Name,
            Description = productDto.Description,
            AvailableQuantity = productDto.AvailableQuantity,
            ImageUrl = productDto.ImageUrl,
            Price = productDto.Price
        }).ToList();
    }
}

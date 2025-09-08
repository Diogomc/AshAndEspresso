using AshAndEspresso.DTOs.Entities;
using AshAndEspresso.Models;

namespace AshAndEspresso.DTOs.Mappings;

public static class ProductDTOMappingExtensions
{
    public static ProductDTO? ToProductDTO(this Product product)
    {
        if (product is null) return null;

        return new ProductDTO
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            AvailableQuantity = product.AvailableQuantity,
            Price = product.Price
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
            ImageUrl = productDto.ImageUrl,
            AvailableQuantity = productDto.AvailableQuantity,
            Price = productDto.Price
        };
    }

    public static IEnumerable<ProductDTO>? ToProductDTOList (this IEnumerable<Product> products)
    {
        if(products == null || !products.Any())
        {
            return new List<ProductDTO>();
        }

        return products.Select(product => new ProductDTO
        {
            ProductId = product.ProductId,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            AvailableQuantity = product.AvailableQuantity,
            Price = product.Price
        }).ToList();
    }
}

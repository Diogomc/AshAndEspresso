using AshAndEspresso.DTOs.Entities;
using AshAndEspresso.DTOs.Mappings;
using AshAndEspresso.Models;
using AshAndEspresso.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AshAndEspresso.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _uow;

    public ProductsController(IUnitOfWork uow)
    {
        _uow = uow;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductDTO>> Get()
    {
        var products = _uow.ProductRepository.GetAll().ToList();
        var productsDto = products.ToProductDTOList();

        return Ok(productsDto);
    }

    [HttpGet("{id:int}", Name="TakeProduct")]
    public ActionResult<ProductDTO> GetProductById(int id)
    {
        var product = _uow.ProductRepository.GetId(p => p.ProductId == id);
        var productDto = product.ToProductDTO();

        return Ok(productDto);
    }

    [HttpPost]
    public ActionResult<ProductDTO> Post(ProductDTO productDto)
    {
        var product = productDto.ToProduct();
        var createProduct = _uow.ProductRepository.Create(product);
        _uow.Commit();

        var productToDto = createProduct.ToProductDTO();

        return new CreatedAtRouteResult("TakeProduct",
            new { id = productToDto.ProductId }, productToDto);
    }

    [HttpDelete("{id:int}")]

    public ActionResult<ProductDTO> Delete(int id)
    {
        var getProductId = _uow.ProductRepository.GetId(p => p.ProductId == id);
        
        var productDelete = _uow.ProductRepository.Delete(getProductId);
        _uow.Commit();

        var productDto = productDelete.ToProductDTO();
        return Ok(productDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<ProductDTO> Put(int id, ProductDTO productDto)
    {
        var product = productDto.ToProduct();

        if(id != product.ProductId)
        {
            return NotFound("Product not found");
        }
        var productUpdate = _uow.ProductRepository.Update(product);
        _uow.Commit();

        var productToDto = productUpdate.ToProductDTO();
        return Ok(productToDto);
    }
}

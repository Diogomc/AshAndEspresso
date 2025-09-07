using AshAndEspresso.DTOs.Entities;
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
    public ActionResult<IEnumerable<Product>> Get()
    {
        return _uow.ProductRepository.GetAll().ToList();
    }

    [HttpGet("{id:int}", Name="TakeProduct")]
    public ActionResult GetProductById(int id)
    {
        var product = _uow.ProductRepository.GetId(p => p.ProductId == id);
        if(id != product.ProductId)
        {
            return NotFound("Product is not found");
        }
        return Ok(product);
    }

    [HttpPost]
    public ActionResult Post(Product product)
    {
        var createProduct = _uow.ProductRepository.Create(product);
        _uow.Commit();
        return new CreatedAtRouteResult("TakeProduct",
            new { id = product.ProductId }, createProduct);
    }

    [HttpDelete("{id:int}")]

    public ActionResult Delete(int id)
    {
        var getProductId = _uow.ProductRepository.GetId(p => p.ProductId == id);
        if(id != getProductId.ProductId)
        {
            return NotFound("Product not found");
        }
        _uow.ProductRepository.Delete(getProductId);
        _uow.Commit();
        return Ok(getProductId);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Product product)
    {
        if(id != product.ProductId)
        {
            return NotFound("Product not found");
        }
        _uow.ProductRepository.Update(product);
        _uow.Commit();
        return Ok(product);
    }
}

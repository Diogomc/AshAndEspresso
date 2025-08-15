using AshAndEspresso.Models;
using AshAndEspresso.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AshAndEspresso.Controllers;

[ApiController]
[Route("api/controller")]
public class ProductsController : ControllerBase
{
    private readonly IRepository<Product> _repository;

    public ProductsController(IRepository<Product> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return _repository.GetAll().ToList();
    }

    [HttpGet("{id:int}", Name="TakeProduct")]
    public ActionResult GetProductById(int id)
    {
        var product = _repository.GetId(p => p.ProductId == id);
        if(id != product.ProductId)
        {
            return NotFound("Product is not found");
        }
        return Ok(product);
    }

    [HttpPost]
    public ActionResult Post(Product product)
    {
        var createProduct = _repository.Create(product);
        return new CreatedAtRouteResult("TakeProduct",
            new { product.ProductId }, createProduct);
    }

    [HttpDelete("{id:int}")]

    public ActionResult Delete(int id)
    {
        var getProductId = _repository.GetId(p => p.ProductId == id);
        if(id != getProductId.ProductId)
        {
            return NotFound("Product not found");
        }
        _repository.Delete(getProductId);
        return Ok(getProductId);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Product product)
    {
        if(id != product.ProductId)
        {
            return NotFound("Product not found");
        }
        _repository.Update(product);
        return Ok(product);
    }
}

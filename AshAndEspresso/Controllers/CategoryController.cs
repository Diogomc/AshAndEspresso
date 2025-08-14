using AshAndEspresso.Models;
using AshAndEspresso.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace AshAndEspresso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;

        public CategoryController(IRepository<Category> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategory()
        {
            var categories = _repository.GetAll().ToList();
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "TakeCategory")]
        public ActionResult GetCategoryId(int id)
        {
            var repository = _repository.GetId(c => c.CategoryId == id);
            return Ok(repository);
        }
        [HttpPost]
        public ActionResult Post(Category category)
        {
           var createCategory = _repository.Create(category);
            return new CreatedAtRouteResult("TakeCategory",
                new { id = createCategory.CategoryId }, createCategory);
            
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var getCategoryId = _repository.GetId(c => c.CategoryId == id);
            _repository.Delete(getCategoryId);

            return Ok(getCategoryId);

        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category)
        {
            if(id != category.CategoryId)
            {
                return NotFound("Category not found");
            }
            _repository.Update(category);
            return Ok(category);
        }
    }
}

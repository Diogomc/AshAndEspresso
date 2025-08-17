using AshAndEspresso.Models;
using AshAndEspresso.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace AshAndEspresso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public CategoryController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategory()
        {
            return _uow.CategoryRepository.GetAll().ToList();
        }

        [HttpGet("{id:int}", Name = "TakeCategory")]
        public ActionResult GetCategoryId(int id)
        {
            var repository = _uow.CategoryRepository.GetId(c => c.CategoryId == id);
            return Ok(repository);
        }
        [HttpPost]
        public ActionResult Post(Category category)
        {
           var createCategory = _uow.CategoryRepository.Create(category);
            _uow.Commit();
            return new CreatedAtRouteResult("TakeCategory",
                new { id = createCategory.CategoryId }, createCategory);

            
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var getCategoryId = _uow.CategoryRepository.GetId(c => c.CategoryId == id);
            _uow.CategoryRepository.Delete(getCategoryId);
            _uow.Commit();

            return Ok(getCategoryId);

        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category)
        {
            if(id != category.CategoryId)
            {
                return NotFound("Category not found");
            }
            _uow.CategoryRepository.Update(category);
            _uow.Commit();
            return Ok(category);
        }
    }
}

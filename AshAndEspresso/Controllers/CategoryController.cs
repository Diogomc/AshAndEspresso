using AshAndEspresso.DTOs.Entities;
using AshAndEspresso.DTOs.Mappings;
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
        public ActionResult<IEnumerable<CategoryDTO>> GetCategory()
        {
            var categories = _uow.CategoryRepository.GetAll().ToList();

            var categoriesDTO = categories.ToCategoryDTOList();
            return Ok(categoriesDTO);
        }


        [HttpGet("{id:int}", Name = "TakeCategory")]
        public ActionResult<CategoryDTO> GetCategoryId(int id)
        {
            var categoryId = _uow.CategoryRepository.GetId(c => c.CategoryId == id);
            var categoryIdDTO = categoryId.ToCategoryDTO();

            return Ok(categoryIdDTO);
        }

        [HttpPost]
        public ActionResult<CategoryDTO> Post(CategoryDTO categoryDto)
        {
            var category = categoryDto.ToCategory();

            var createCategory = _uow.CategoryRepository.Create(category);
            _uow.Commit();

            var categoryToDto = createCategory.ToCategoryDTO();

            return new CreatedAtRouteResult("TakeCategory",
                new { id = categoryToDto.CategoryId }, categoryToDto);     
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CategoryDTO> Delete(int id)
        {
            var getCategoryId = _uow.CategoryRepository.GetId(c => c.CategoryId == id);

            var deleteCategory = _uow.CategoryRepository.Delete(getCategoryId);
            _uow.Commit();

            var deleteDto = deleteCategory.ToCategoryDTO();
            return Ok(deleteDto);

        }
        [HttpPut("{id:int}")]
        public ActionResult<CategoryDTO> Put(int id, CategoryDTO categoryDto)
        {
            if(id != categoryDto.CategoryId)
            {
                return NotFound("Category not found");
            }
            var category = categoryDto.ToCategory();

            var categoryUpdate = _uow.CategoryRepository.Update(category);
            _uow.Commit();

            var categoryToDto = categoryUpdate.ToCategoryDTO();
            return Ok(categoryToDto);
        }
    }
}

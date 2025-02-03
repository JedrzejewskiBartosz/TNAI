using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using TNAI.Dto.Categories;
using TNAI.Model.Entities;
using TNAI.Repository.Categories;


namespace TNAI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);

            if (category == null) return NotFound();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            if (!categories.Any()) return NotFound();

            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            return Ok(categoriesDto);
        }


        [HttpPost]

        public async Task<IActionResult> Post([FromBody] CategoryInputDto category)
        {
            if (category == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newCategory = new Category()
            {
                Name = category.Name
            };

            var result = await _categoryRepository.SaveCategorysAsync(newCategory);
            if (!result) throw new Exception("ERROR save");

            var categoryDto = _mapper.Map<CategoryDto>(newCategory);

            return Ok(categoryDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoryInputDto category)
        {
            if (category == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            if (existingCategory == null) return NotFound();

            existingCategory.Name = category.Name;

            var result = await _categoryRepository.SaveCategorysAsync(existingCategory);
            if (!result) throw new Exception("ERROR upt");

            var categoryDto = _mapper.Map<CategoryDto>(existingCategory);

            return Ok(categoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            if (existingCategory == null) return NotFound();

            var result = await _categoryRepository.DeleteCategorysAsync(id);
            if (!result) throw new Exception("ERROR del");

            return Ok();
        }
    }
}

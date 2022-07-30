using Microsoft.AspNetCore.Mvc;
using WebAPI.Business.Abstact;

namespace WebAPI.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (result.Process) 
            {
                return Ok(result); 
            }   
            return BadRequest(result);
        }
    }
}

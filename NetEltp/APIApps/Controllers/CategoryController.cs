using APIApps.Services;
using Microsoft.AspNetCore.Mvc;
using APIApps.Models;
namespace APIApps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IDbAccessService<Category, int> catService;
        /// <summary>
        /// Inject the Service Dependency
        /// </summary>
        public CategoryController(IDbAccessService<Category, int> serv)
        {
            catService = serv;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await catService.GetAsync();
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await catService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                // Check if the CategoryName is already present
                var isCategoryExist = (await catService.GetAsync())
                                        .Where(c => c.CategoryName == cat.CategoryName)
                                        .FirstOrDefault();
                if (isCategoryExist != null)
                    throw new Exception("There is alreay a Category with Name {cat.CategoryName} exist.");
                //return Conflict($"There is alreay a Category with Name {cat.CategoryName} exist.");

                var result = await catService.CreateAsync(cat);
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id,Category cat)
        {
            if (cat.CategoryName.Length > 10)
                throw new Exception($"Sorry I cannot accept such a Length for Category Name");
            var result = await catService.UpdateAsync(id, cat);
            return Ok(result);
        }
      
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await catService.DeleteAsync(id);
            return Ok(res);
        }
    }
}

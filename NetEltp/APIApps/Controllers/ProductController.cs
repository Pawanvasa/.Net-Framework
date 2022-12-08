using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIApps.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IDbAccessService<Product, int> prodService;
        eShoppingContext context;
        /// <summary>
        /// Inject the Service Dependency
        /// </summary>
        public ProductController(IDbAccessService<Product, int> serv, IDbAccessService<Category, int> categoryService, eShoppingContext context)
        {
            prodService = serv;
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await prodService.GetAsync();
            if(result == null)
            {
                throw new Exception("The request failed to procces data");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var result = (await prodService.GetAsync())
                    .Where(c=>c.CategoryId==product.CategoryId)
                    .FirstOrDefault();
                /*if (result == null)
                {
                    throw new Exception($"{product.CategoryId} not There in the Category Table ");
                }*/
                var res = await prodService.CreateAsync(product);
                return Ok(res);
            }
            return BadRequest();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                var result = (await prodService.GetAsync())
                    .Where(c => c.ProductId == product.ProductId)
                    .FirstOrDefault();
                if (result == null)
                {
                    throw new Exception($"{product.CategoryId} not There in the Product Table ");
                }
            }
            var res = await prodService.UpdateAsync(id, product);
            return Ok(res);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await prodService.GetAsync(id);
                if(result==null)
                {
                    throw new Exception($"{id} not There in the Product Table ");
                }
            }
            var res = await prodService.DeleteAsync(id);
            return Ok(res);
        }
    }
}

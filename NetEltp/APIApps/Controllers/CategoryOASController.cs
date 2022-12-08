using APIApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using APIApps.Models;
namespace APIApps.Controllers
{
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CategoryOASController : ControllerBase
    {
        IDbAccessService<Category, int> catDbAccess;
        public CategoryOASController(IDbAccessService<Category, int> catDbAccess)
        {
            this.catDbAccess = catDbAccess;
        }

        [HttpGet("/getcategoties")]
        public async Task<IEnumerable<Category>> Get()
        {
            var result = await catDbAccess.GetAsync();
            return result;
        }

        [HttpPost("/createcategory")]
        public async Task<Category> Post(Category category)
        {
            var result = await catDbAccess.CreateAsync(category);
            return result;
        }
        [HttpPut("/UpdateCategory")]
        public async Task<Category> Put(int id,Category cat)
        {
            var result=await catDbAccess.UpdateAsync(id, cat);
            return result;
        }

        [HttpDelete("/DeleteCategory")]
        public async Task<bool> Delete(int id)
        {
            var result = await catDbAccess.DeleteAsync(id);
            return result;
        }
    }
}

/*using APIApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIApps.Models;
namespace APIApps.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BinderAPIController : ControllerBase
    {
        IDbAccessService<Category,int> catServ;

        public BinderAPIController(IDbAccessService<Category, int> catServ)
        {
            this.catServ = catServ;
        }
        [HttpPost]
        // THis Action NAme will be used by the CLient
        [ActionName("postparam")]
        public async Task<IActionResult> PostParameters(int CategoryId, string CategoryName, decimal BasePrice)
        {   
            return Ok();
        }

        [HttpPost]
        // THis Action NAme will be used by the CLient
        [ActionName("postquery")]
        public async Task<IActionResult> PostFromQuery([FromQuery] Category cat)
        {
            return Ok();
        }

        [HttpPost("{categoryid}/{categoryname}/{baseprice}")]
        // THis Action NAme will be used by the CLient
        [ActionName("postroute")]
        public async Task<IActionResult> PostFromRoute([FromRoute] Category cat)
        {
            return Ok();
        }
    }
}*/
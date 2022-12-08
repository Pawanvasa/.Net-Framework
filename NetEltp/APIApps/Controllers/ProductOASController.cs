using APIApps.Models;
using APIApps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Mime;

namespace APIApps.Controllers
{
    [Route("api/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class ProductOASController : ControllerBase
    {
        eShoppingContext context;
        public ProductOASController(eShoppingContext context)
        {
            this.context = context;
        }
        [HttpGet("/GetProdByCatId")]
        public async Task<IEnumerable<Product>> GetProdByCatID(String CategoryName, int numberOfRecords)
        {
            try

            {
                var product = await (from cat in context.Categories
                               join prod in context.Products
                               on cat.CategoryId equals prod.CategoryId
                               where cat.CategoryName == CategoryName
                               select prod).ToListAsync(); ;
                //int? skip=0;
                int totalRecords = product.Count();
               /* if (HttpContext.Session.GetInt32("skip") != 0)
                {*/
                   int skip = Convert.ToInt32(HttpContext.Session.GetInt32("skip"));
                //}
                if (numberOfRecords == 0 && skip==0)
                {
                    product = (from cat in context.Categories
                               join prod in context.Products
                               on cat.CategoryId equals prod.CategoryId
                               where cat.CategoryName == CategoryName
                               select prod).ToList();
                }
              
                if (numberOfRecords > 0 && skip == 0)
                {
                    product = (from cat in context.Categories
                               join prod in context.Products
                               on cat.CategoryId equals prod.CategoryId
                               where cat.CategoryName == CategoryName
                               select prod).Take(Convert.ToInt32(numberOfRecords)).ToList();
                    HttpContext.Session.SetInt32("skip", numberOfRecords);
                }
                if (numberOfRecords > 0 && skip > 0)
                {
                    product = (from cat in context.Categories
                               join prod in context.Products
                               on cat.CategoryId equals prod.CategoryId
                               where cat.CategoryName == CategoryName
                               select prod).Skip(Convert.ToInt32(skip)).Take(Convert.ToInt32(numberOfRecords)).ToList();
                }
                if( skip <=numberOfRecords)
                {
                    return product;
                }
                else
                {
                    return null!;
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

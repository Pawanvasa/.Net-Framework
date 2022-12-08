using APIAss04.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using APIApps.Models;
using System.Net.Mime;

namespace APIAss04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryCacheController : ControllerBase
    {
        IMemoryCache memoryCache;
        private string cacheKey = "records";
        NorthWindContext context;
        public CategoryCacheController(IMemoryCache memoryCache, NorthWindContext context)
        {
            this.memoryCache = memoryCache;
            this.context = context;
        }

        [HttpGet("/getDetails")]
        public async Task<ResponseObject> GetAsync()
        {
            ResponseObject response = new ResponseObject();
            List<CustomersEmployeesShipper> result = null;
            try
            {
                // 1. Try to Get data from Cache
                var isDataAvaiableInCache = memoryCache.TryGetValue(cacheKey, out result);
                // 2. If Null then REad data from Db Server and Add in cache
                if (!isDataAvaiableInCache)
                {
                    result = (context.CustomersEmployeesShippers).ToList();
                    response.Categories = result;
                    response.Message = "Data is received from Database";
                    // 2.a. define Options for data in cache
                    var memoryCacheOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(2))
                        .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
                    // 2.b. Add Data in Cache
                    memoryCache.Set(cacheKey, result,
                        memoryCacheOptions);
                }
                else
                {
                    response.Categories = result;
                    response.Message = "Data is Received from Cache";
                }

                // 3. Return Response
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

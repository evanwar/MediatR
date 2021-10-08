using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SpecificationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }

        //[HttpGet]
        //public Task<IActionResult> Get()
        //{
        //    return Ok();
        //}
    }
}

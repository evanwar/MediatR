using Microsoft.AspNetCore.Mvc;
using SpecificationDemo.Models;
using SpecificationDemo.Specifications;
using System;
using System.Linq.Expressions;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult result;

            var product = new ProductRepository().GetProductById(id);

            var specification = new ProductAvailableSpecification();




            if (!product.Discontinued && product.UnitsInStock > 0)
            {
                result = Ok();
            }
            else
            {
                result = BadRequest();
            }

            return result;
        }


        [HttpGet("available")]
        public IActionResult GetAvailable()
        {
            return Ok(new ProductRepository().FindAvailableForSale());
        }


        [HttpGet("with-expression/{id}")]
        public IActionResult IsAvailableForSaleWithExpression(int id)
        {

            var product = new ProductRepository().GetProductById(id);

            Expression<Func<Product, bool>> conditionExpression = product => !product.Discontinued && product.UnitsInStock > 0;

            bool isAvailable = conditionExpression.Compile().Invoke(product);

            return Ok(isAvailable);
        }


        [HttpGet("products-with-expression/{id}")]
        public IActionResult GetAvailableWithExpression(int id)
        {
            var product = new ProductRepository().Find(x => x.Id == id);

            return Ok(product);
        }


        [HttpGet("with-specification/{id}")]
        public IActionResult IsAvailableForSale(int id)
        {

            var product = new ProductRepository().GetProductById(id);

            var specification = new GenericSpecification<Product>(x=>!x.Discontinued && x.UnitsInStock>0);

            bool isAvailable = specification.IsSatisfiedBy(product);

            return Ok(isAvailable);
        }


        [HttpGet("with-specification/{id}")]
        public IActionResult IsAvailableForSaleSpecification(int id)
        {

            var product = new ProductRepository().GetProductById(id);

            var specification = new ProductAvailableForSaleSpecification();

            bool isAvailable = specification.IsSatisfiedBy(product);

            return Ok(isAvailable);
        }


    }
}

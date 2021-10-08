using FluentValidationApi.Models;
using FluentValidationApi.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {




        public ProductsController()
        {

        }

        [HttpGet("validate-product")]
        public async Task<IActionResult> Validate(string name)
        {
            IActionResult result;


            var product = new Product { Name = name };

            var validator = new ProductValidator();

            var validationResult = await validator.ValidateAsync(product);

            if (validationResult.IsValid)
            {
                result = Ok(product);
            }
            else
            {
                StringBuilder builder = new StringBuilder();

                foreach (var error in validationResult.Errors)
                {
                    builder.AppendLine(string.Format("Propiedad: {0}, Error: {1}", error.PropertyName, error.ErrorMessage));
                }

                result = BadRequest(builder.ToString());
            }


            return result;
        }
    }
}

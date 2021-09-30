using CQR.Aplication.Commands;
using CQR.Aplication.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            IActionResult Result = BadRequest("No se ha creado el producto.");

            int Id = await mediator.Send(command);

            if (Id > 0)
            {
                Result = Ok($"Producto creado : {Id}");
            }

            return Result;
        }



        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            IActionResult Result = BadRequest("No se ha modificado el producto.");

            if (await mediator.Send(command))
            {
                Result = Ok($"Producto actualizado : {command.Id}");
            }

            return Result;
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            IActionResult Result = BadRequest("No se ha eliminado el producto.");

            if (await mediator.Send(command))
            {
                Result = Ok($"Producto eliminado : {command.Id}");
            }

            return Result;
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllProductQuery()));
        }


        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            IActionResult Result = BadRequest("Elemento no encontrado");

            var product = await mediator.Send(new GetProductByIdQuery { Id = id });

            if (product != null)
            {
                Result = Ok(product);
            }

            return Result;
        }


    }
}

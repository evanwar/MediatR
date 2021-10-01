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
            return Ok(await mediator.Send(command));
        }



        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }




        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }


        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllProductQuery()));
        }


        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetProductByIdQuery { Id = id }));
        }


    }
}

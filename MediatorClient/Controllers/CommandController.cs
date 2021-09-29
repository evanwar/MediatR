using CommandsAndHandlers;
using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatorClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly IMediator mediator;

        public CommandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(string name)
        {
            int id = await mediator.Send(new CreateProduct { Product = name });

            return Ok(id);
        }



        [HttpDelete]
        public async Task<IActionResult> CreateProduct(int id)
        {
            await mediator.Send(new DeleteProduct { Id = id });

            return Ok();
        }

    }
}

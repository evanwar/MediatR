using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Behaviors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BehaviorController : ControllerBase
    {
        private readonly IMediator mediator;

        public BehaviorController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(string name)
        {
            IActionResult result;

            try
            {
                int id = await mediator.Send(new CreateProduct { Name = name });

                result = Ok(id);
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;

        }



    }
}

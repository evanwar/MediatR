using MadiatRDemo.Ports;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MadiatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMediator mediator;

        public MessageController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Send()
        {
            var response = await mediator.Send(new Ping());

            return Ok(response);
        }


        [HttpGet("send-without")]
        public async Task<IActionResult> SendWithout()
        {
            return Ok(await mediator.Send(new OneWay()));
        }


        [HttpGet("create-product")]
        public async Task<IActionResult> CreateProduct()
        {
            var presenter = new Presenter();


            await mediator.Send(new CreateProduct("Pan", presenter));

            return Ok(presenter.Content);
        }


        [HttpGet("pong1")]
        public async Task<IActionResult> Pong1()
        {

            await mediator.Publish(new PingNotification());

            return Ok();
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        [HttpGet]
        public IActionResult SaveChanges()
        {
            PersitenceService service = new PersitenceService(new NotificationHandler1(), new NotificationHandler2(), new NotificationHandler3());

            service.SaveChanges();

            return Ok();
        }
    }
}

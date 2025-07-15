using gestaoTec.Application.Models;
using gestaoTec.Application.Services.Iservices;
using gestaoTec.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {

        [HttpPost]

        public async Task<IActionResult> Save(
            [FromServices] IClientService service,
            [FromBody] SaveClient model,
            CancellationToken token = default)
        {
         var result = await service.SaveAsync(model);
         return Ok(result);
        }


    }
}

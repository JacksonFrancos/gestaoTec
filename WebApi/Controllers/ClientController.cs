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
            var client = Client.Create(
           model.Name,
           model.Email,
           model.Address,
           model.ClientId
           );
         client.Number = model.Number;
         var result = await service.SaveAsync(client);


            return Ok(result);

        }


    }
}

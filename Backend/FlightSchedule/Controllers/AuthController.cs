using FlightSchedule.Application.Interfaces;
using FlightSchedule.Domain.Entities;
using FlightSchedule.Infra.CrossCutting.Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FlightSchedule.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ApiController
    {
        private readonly IAuthAppService _authAppService;
        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody]User user)
        {
            var result = await _authAppService.GenerateToken(user);
            return result.StatusCode.IsSuccessStatusCode()
                        ? new OkObjectResult(result.Value)
                        : StatusCode((int)result.StatusCode, GenerateProblemsDetail(result));
        }
    }
}

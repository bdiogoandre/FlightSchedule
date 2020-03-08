using FlightSchedule.Application.Interfaces;
using FlightSchedule.Controllers;
using FlightSchedule.Domain.Models.Request;
using FlightSchedule.Infra.CrossCutting.Extention;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSchedule.Services.Api.Controllers
{
    [ApiController]
    [Route("api/flights")]
    [Authorize(Roles = "administrator")]
    public class FlightScheduleController : ApiController
    {
        private readonly IFlightScheduleAppService _flightAppSchedule;
        public  FlightScheduleController(IFlightScheduleAppService flightScheduleAppService)
        {
            _flightAppSchedule = flightScheduleAppService;
        }
        [HttpGet]
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _flightAppSchedule.ListAllFlightsAsync(cancellationToken);
            return result.StatusCode.IsSuccessStatusCode()
                ? new OkObjectResult(result.Value)
                : StatusCode((int)result.StatusCode, GenerateProblemsDetail(result));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id, CancellationToken cancellationToken)
        {
            var result = await _flightAppSchedule.GetFlightByIdAsync(id);
            return result.StatusCode.IsSuccessStatusCode()
                ? new OkObjectResult(result.Value)
                : StatusCode((int)result.StatusCode, GenerateProblemsDetail(result));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FlightScheduleRequest flightRequest, CancellationToken cancellationToken)
        {
            var result = await _flightAppSchedule.CreateFlightAsync(flightRequest, cancellationToken);
            return result.StatusCode.IsSuccessStatusCode()
                ? new CreatedResult($"{Request.Host.Value}{Request.Path.Value}/{result.Value}", new { id = result.Value })
                : StatusCode((int)result.StatusCode, GenerateProblemsDetail(result));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var result = await _flightAppSchedule.RemoveFlightAsync(id, cancellationToken);

            return result.StatusCode.IsSuccessStatusCode()
                ? new OkObjectResult(result.Value)
                : StatusCode((int)result.StatusCode, GenerateProblemsDetail(result));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] FlightScheduleRequest flightRequest, CancellationToken cancellationToken)
        {
            var result = await _flightAppSchedule.ReplaceFlightAsync(flightRequest, cancellationToken);
            return result.StatusCode.IsSuccessStatusCode()
                ? new OkObjectResult(result.Value)
                : StatusCode((int)result.StatusCode, GenerateProblemsDetail(result));
        }
    }
}

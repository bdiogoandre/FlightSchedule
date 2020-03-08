using FlightSchedule.Domain.Models;
using FlightSchedule.Domain.Models.Request;
using FlightSchedule.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSchedule.Application.Interfaces
{
    public interface IFlightScheduleAppService
    {
        Task<Result<IEnumerable<FlightScheduleResponse>>> ListAllFlightsAsync(CancellationToken cancellationToken);
        Task<Result<FlightScheduleResponse>> GetFlightByIdAsync(string id);
        Task<Result<string>> CreateFlightAsync(FlightScheduleRequest flightRequest, CancellationToken cancellationToken);
        Task<Result<long>> RemoveFlightAsync(string id, CancellationToken cancellationToken);
        Task<Result<long>> ReplaceFlightAsync(FlightScheduleRequest flightRequest, CancellationToken cancellationToken);
    }
}

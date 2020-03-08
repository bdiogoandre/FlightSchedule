using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Models;
using FlightSchedule.Domain.Models.Request;
using FlightSchedule.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSchedule.Domain.Interfaces.Services
{
    public interface IFlightScheduleService : IServiceBase<FlightScheduleModel>
    {
        Task<Result<string>> CreateAsync(FlightScheduleRequest flightRequest, CancellationToken cancellationToken);
        Task<Result<long>> RemoveAsync(string id, CancellationToken cancellationToken);
        Task<Result<long>> ReplaceAsync(FlightScheduleRequest flightRequest, CancellationToken cancellationToken);
        Task<Result<IEnumerable<FlightScheduleResponse>>> ListAllFlightsAsync(CancellationToken cancellationToken);
    }
}

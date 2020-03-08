using FlightSchedule.Application.Interfaces;
using FlightSchedule.Domain.Interfaces.Services;
using FlightSchedule.Domain.Models;
using FlightSchedule.Domain.Models.Request;
using FlightSchedule.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSchedule.Application.AppServices
{
    public class FlightScheduleAppService : IFlightScheduleAppService
    {
        private readonly IFlightScheduleService _flightScheduleService;
        public FlightScheduleAppService(IFlightScheduleService flightScheduleService)
        {
            _flightScheduleService = flightScheduleService;
        }
        public async Task<Result<IEnumerable<FlightScheduleResponse>>> ListAllFlightsAsync( CancellationToken cancellationToken)
        {
            return await _flightScheduleService.ListAllFlightsAsync(cancellationToken);
        }
        public async Task<Result<FlightScheduleResponse>> GetFlightByIdAsync(string id)
        {
            return await _flightScheduleService.GetByIdAsync<FlightScheduleResponse>(id);
        }
        public async Task<Result<string>> CreateFlightAsync(FlightScheduleRequest flightRequest, CancellationToken cancellationToken)
        {
            return await _flightScheduleService.CreateAsync(flightRequest, cancellationToken);
        }
        public async Task<Result<long>> RemoveFlightAsync(string id, CancellationToken cancellationToken)
        {
            return await _flightScheduleService.RemoveAsync(id, cancellationToken);
        }
        public async Task<Result<long>> ReplaceFlightAsync(FlightScheduleRequest flightRequest, CancellationToken cancellationToken)
        {
            return await _flightScheduleService.ReplaceAsync(flightRequest, cancellationToken);
        }
    }
}

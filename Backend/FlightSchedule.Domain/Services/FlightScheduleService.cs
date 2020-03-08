using AutoMapper;
using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Interfaces.Repositories;
using FlightSchedule.Domain.Interfaces.Services;
using FlightSchedule.Domain.Models;
using FlightSchedule.Domain.Models.Request;
using FlightSchedule.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSchedule.Domain.Services
{
    public class FlightScheduleService : ServiceBase<FlightScheduleModel>, IFlightScheduleService 
    {
        public readonly IFlightScheduleRepository _flightScheduleRepository;
        public FlightScheduleService(IFlightScheduleRepository flightScheduleRepository, IMapper mapper) : base(flightScheduleRepository, mapper)
        {
            _flightScheduleRepository = flightScheduleRepository;
            _mapper = mapper;
        }
        public async Task<Result<string>> CreateAsync(FlightScheduleRequest flightRequest, CancellationToken cancellationToken)
        {
            return await this.AddAsync<FlightScheduleRequest>(flightRequest, cancellationToken);
        }
        public async Task<Result<long>> RemoveAsync(string id, CancellationToken cancellationToken)
        {
            return await this.DeleteByIdAsync(id, cancellationToken);
        }
        public async Task<Result<long>> ReplaceAsync(FlightScheduleRequest flightRequest, CancellationToken cancellationToken)
        {
            return await this.ReplaceOneAsync(flightRequest, cancellationToken);
        }
        public async Task<Result<IEnumerable<FlightScheduleResponse>>> ListAllFlightsAsync(CancellationToken cancellationToken)
        {
            return await this.AllAsync<FlightScheduleResponse>(cancellationToken);
        }
        public async Task<Result<FlightScheduleResponse>> GetFlightByIdAsync(string id)
        {
            return await this.GetByIdAsync<FlightScheduleResponse>(id);
        }
    }
}

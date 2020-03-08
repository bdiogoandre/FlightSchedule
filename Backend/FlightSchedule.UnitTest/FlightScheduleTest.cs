using AutoMapper;
using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Interfaces.Repositories;
using FlightSchedule.Domain.Interfaces.Services;
using FlightSchedule.Domain.Models.Request;
using FlightSchedule.Domain.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Xunit;

namespace FlightSchedule.UnitTest
{
    public class FlightScheduleTest
    {
        private readonly IFlightScheduleRepository _flightScheduleRepository;
        private readonly IFlightScheduleService _flightScheduleService;
        private readonly IMapper _mapper;
        private readonly CancellationToken _cancellationToken;

        public FlightScheduleTest()
        {
            _flightScheduleRepository = Substitute.For<IFlightScheduleRepository>();
            _mapper = Substitute.For<IMapper>();

            _flightScheduleService = new FlightScheduleService(_flightScheduleRepository, _mapper);

            _cancellationToken = new CancellationToken();
        }

        [Fact]
        public async void AddOne_NullValue_ReturnsError()
        {
            FlightScheduleRequest flightRequest = null;

            var result = await _flightScheduleService.CreateAsync(flightRequest, _cancellationToken);

            Assert.True(result.StatusCode == HttpStatusCode.BadRequest);
            Assert.True(result.ProblemTittle == "Object is null");
        }

        [Fact]
        public async void AddOne_NullOrWhiteSpaceName_ReturnsError()
        {
            var flightRequest = new FlightScheduleRequest()
            {
                DataHoraPartida = Convert.ToDateTime("08/03/2020 18:46"),
                Destino = "Recife",
                Origem = "São Paulo",
                Nome = " "
            };

            var flight = new FlightScheduleModel()
            {
                Id = "werogninerpgnperiogn",
                DataHoraPartida = Convert.ToDateTime("08/03/2020 18:46"),
                Destino = "Recife",
                Origem = "São Paulo",
                Nome = " "
            };
            _mapper.Map<FlightScheduleRequest, FlightScheduleModel>(default)
                .ReturnsForAnyArgs(x => flight);

            _flightScheduleRepository.AddAsync(flight, _cancellationToken)
                .ReturnsForAnyArgs(x => flight);

            var error = new Dictionary<string, List<string>>()
            {
                {"Nome", new List<string>() { "Cannot be null or empty" } }
            };
            var result = await _flightScheduleService.CreateAsync(flightRequest, _cancellationToken);

            Assert.True(result.StatusCode == HttpStatusCode.BadRequest);
            Assert.Contains(error, result.Errors);
        }

        [Fact]
        public async void AddOne_Ok()
        {
            var flightRequest = new FlightScheduleRequest()
            {
                DataHoraPartida = Convert.ToDateTime("08/03/2020 18:46"),
                Destino = "Recife",
                Origem = "São Paulo",
                Nome = "Bruno André"
            };

            var flight = new FlightScheduleModel()
            {
                Id = "werogninerpgnperiogn",
                DataHoraPartida = Convert.ToDateTime("08/03/2020 18:46"),
                Destino = "Recife",
                Origem = "São Paulo",
                Nome = "Bruno André"
            };
            

            _mapper.Map<FlightScheduleRequest, FlightScheduleModel>(default)
                .ReturnsForAnyArgs(x => flight);
            
            _flightScheduleRepository.AddAsync(flight, _cancellationToken)
                .ReturnsForAnyArgs(x => flight);

            var result = await _flightScheduleService.CreateAsync(flightRequest, _cancellationToken);

            Assert.True(result.StatusCode == HttpStatusCode.Created);
        }

        //[Fact]
        //public async void Update_NullFilter_ReturnsError()
        //{
        //    var filter = 
        //}
    }
}

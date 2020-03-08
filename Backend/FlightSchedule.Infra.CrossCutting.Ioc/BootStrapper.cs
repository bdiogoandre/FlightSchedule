using AutoMapper;
using FlightSchedule.Application;
using FlightSchedule.Application.AppServices;
using FlightSchedule.Application.Interfaces;
using FlightSchedule.Domain.AutoMappers;
using FlightSchedule.Domain.Interfaces.Repositories;
using FlightSchedule.Domain.Interfaces.Services;
using FlightSchedule.Domain.Services;
using FlightSchedule.Infra.Data.Context;
using FlightSchedule.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FlightSchedule.Infra.CrossCutting.Ioc
{
    [ExcludeFromCodeCoverage]
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new List<Profile>()
                {
                    new DomainToResponseMappingProfile(),
                    new RequestToDomainMappingProfile()
                });
            });

            var connectionStringMongo = "mongodb://bdiogoangineer:1123581321Fi@cluster0-shard-00-00-rm3so.azure.mongodb.net:27017,cluster0-shard-00-01-rm3so.azure.mongodb.net:27017,cluster0-shard-00-02-rm3so.azure.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";

            services.AddSingleton<IMongoContextBase>(new MongoContext(connectionStringMongo))
                    .AddSingleton<IFlightScheduleRepository, FlightScheduleRepository>()

                    .AddSingleton<IFlightScheduleService, FlightScheduleService>()
                    .AddSingleton<IAuthAppService, AuthAppService>()
                    .AddSingleton<IFlightScheduleAppService, FlightScheduleAppService>()
                    .AddSingleton(s => configMapper.CreateMapper());
        }
    }
}

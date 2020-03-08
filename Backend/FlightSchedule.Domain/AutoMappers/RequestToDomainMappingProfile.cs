using AutoMapper;
using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Models.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FlightSchedule.Domain.AutoMappers
{
    [ExcludeFromCodeCoverage]
    public class RequestToDomainMappingProfile : Profile
    {
        public RequestToDomainMappingProfile()
        {
            CreateMap<FlightScheduleRequest, FlightScheduleModel>();
        }
    }
}

using AutoMapper;
using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using FlightSchedule.Infra.CrossCutting.Extention;

namespace FlightSchedule.Domain.AutoMappers
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<FlightScheduleModel, FlightScheduleResponse>()
                .ForMember(d => d.CriadoEmFormatado, o => o.MapFrom(c => c.CriadoEm.FormatValue()))
                .ForMember(d => d.UltimaAlteracaoFormatado, o => o.MapFrom(c => c.UltimaAlteracao.FormatValue()));
        }
    }
}

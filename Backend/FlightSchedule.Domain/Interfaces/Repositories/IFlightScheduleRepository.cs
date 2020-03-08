using FlightSchedule.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Domain.Interfaces.Repositories
{
    public interface IFlightScheduleRepository : IMongoRepository<FlightScheduleModel>
    {
    }
}

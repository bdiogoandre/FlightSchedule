using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Infra.Data.Repositories
{
    public class FlightScheduleRepository : MongoRepository<FlightScheduleModel>, IFlightScheduleRepository
    {
        public FlightScheduleRepository(IMongoContextBase mongoContext)
        {
            dataContext = mongoContext;
        }
    }
}

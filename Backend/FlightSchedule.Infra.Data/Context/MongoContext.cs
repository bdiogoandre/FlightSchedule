using FlightSchedule.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Infra.Data.Context
{
    public class MongoContext : MongoContextBase, IMongoContextBase
    {
        public MongoContext(string connection) : base(connection)
        {

        }
    }
}

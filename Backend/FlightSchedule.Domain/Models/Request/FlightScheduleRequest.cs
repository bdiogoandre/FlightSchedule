using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Domain.Models.Request
{
    public class FlightScheduleRequest : BaseRequest
    {
        
        public string Nome { get; set; }

        public DateTime DataHoraPartida { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }
    }
}

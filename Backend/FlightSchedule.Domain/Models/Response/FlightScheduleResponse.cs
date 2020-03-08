using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Domain.Models.Response
{
    public class FlightScheduleResponse : BaseResponse
    {
        public string Nome { get; set; }

        public DateTime DataHoraPartida { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }
    }
}

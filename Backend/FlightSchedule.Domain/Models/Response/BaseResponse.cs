using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Domain.Models.Response
{
    public class BaseResponse
    {
        public string Id { get; set; }
        public string CriadoEmFormatado { get; set; }
        public string UltimaAlteracaoFormatado { get; set; }
    }
}

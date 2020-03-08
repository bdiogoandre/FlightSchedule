using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace FlightSchedule.Infra.CrossCutting.Extention
{
    public static class HttpStatusCodeExtension
    {
        public static bool IsSuccessStatusCode(this HttpStatusCode value)
        {
            int statusCode = (int)value;
            return (statusCode >= 200 && statusCode < 300);
        }
    }
}

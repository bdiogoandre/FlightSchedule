using System;

namespace FlightSchedule.Infra.CrossCutting.Extention
{
    public static class DateTimeExtention
    {
        public static string FormatValue(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy hh:mm:ss");
        }
    }
}

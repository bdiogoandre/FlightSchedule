using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Domain.Models
{
    public class ProblemsDetail
    {
        public string Tittle { get; private set; }
        public string Detail { get; private set; }
        public string Instance { get; private set; }
        public int Status { get; private set; }
        public string Type { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "errors")]
        public List<Dictionary<string, List<string>>> Errors { get; set; }
        #region Constructors
        public ProblemsDetail(int status, string instance, string tittle = null, string detail = null, List<Dictionary<string, List<string>>> errors = null)
        {
            Status = status;
            Instance = instance;
            Tittle = string.IsNullOrWhiteSpace(tittle) ? "One or more validation errors occured." : tittle;
            if (errors != null)
                Detail = "Please, refer to the errors for additional details";

            Errors = errors;
            Type = "about:blank";
        }
        #endregion Constructors

        public static Dictionary<string, List<string>> GenerateError(string propertyName, string errorMessage)
        {
            var properties = new Dictionary<string, List<string>>();
            properties.Add(propertyName, new List<string>() { errorMessage });
            return properties;
        }
        public static List<Dictionary<string, List<string>>> GenerateOneError(string propertyName, string errorMessage)
        {
            var properties = new Dictionary<string, List<string>>();
            properties.Add(propertyName, new List<string>() { errorMessage });
            return new List<Dictionary<string, List<string>>>() { properties };
        }
    }
}

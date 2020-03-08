using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text;

namespace FlightSchedule.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class Result
    {
        public HttpStatusCode StatusCode { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ProblemTittle { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ProblemDetail { get; private set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Dictionary<string, List<string>>> Errors { get; set; }

        public Result(HttpStatusCode statusCode, string problemTittle = null, string problemDetail = null, List<Dictionary<string, List<string>>> errors = null)
        {
            StatusCode = statusCode;
            ProblemTittle = problemTittle;
            ProblemDetail = problemDetail;
            Errors = errors;
        }
    }
    public class Result<T> : Result
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T Value { get; set; }
        public Result(T value, HttpStatusCode statusCode,
                        string problemTittle = null,
                        string problemDetail = null,
                        List<Dictionary<string, List<string>>> errors = null)
                    : base(statusCode, problemTittle, problemDetail, errors)
        {
            Value = value;
        }
    }
}

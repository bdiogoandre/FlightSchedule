using System;
using System.Collections.Generic;
using FlightSchedule.Domain.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FlightSchedule.Infra.CrossCutting.Extention;

namespace FlightSchedule.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected string GetInstanceRequest()
        {
            return $"{Request.Host.Value}{Request.Path.Value}";
        }

        protected ProblemsDetail GenerateProblemsDetail(Result result)
        {
            if (result.StatusCode.IsSuccessStatusCode())
                throw new InvalidOperationException();

            return new ProblemsDetail((int)result.StatusCode, GetInstanceRequest(), result.ProblemTittle, result.ProblemDetail, result.Errors);

        }
    }
}

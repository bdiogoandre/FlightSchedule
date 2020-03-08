using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Models;
using FlightSchedule.Domain.Models.Response;
using System.Threading.Tasks;

namespace FlightSchedule.Application.Interfaces
{
    public interface IAuthAppService
    {
        public Task<Result<UserResponse>> GenerateToken(User user);
    }
}

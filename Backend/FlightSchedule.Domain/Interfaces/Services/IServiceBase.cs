using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Models;
using FlightSchedule.Domain.Models.Request;
using FlightSchedule.Domain.Models.Response;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSchedule.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : Entity
    {
        Task<Result<string>> AddAsync<TRequest>(TRequest obj, CancellationToken cancellationToken) where TRequest : BaseRequest;
        Task<Result<long>> UpdateAsync(Expression<Func<TEntity, bool>> filter, UpdateDefinition<TEntity> update, CancellationToken cancellationToken);
        Task<Result<TResponse>> GetByIdAsync<TResponse>(string id) where TResponse : BaseResponse;
        Task<Result<IEnumerable<TResponse>>> GetAsync<TResponse>(Expression<Func<TEntity, bool>> filter) where TResponse : BaseResponse;
        Task<Result<IEnumerable<TResponse>>> AllAsync<TResponse>(CancellationToken cancellationToken) where TResponse : BaseResponse;
        Task<Result<long>> DeleteByIdAsync(string id, CancellationToken cancellationToken);
        Task<Result<long>> DeleteAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
        Task<Result<long>> CountAsync(Expression<Func<TEntity, bool>> filter);
        Task<Result<long>> ReplaceOneAsync<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : BaseRequest;
    }
}

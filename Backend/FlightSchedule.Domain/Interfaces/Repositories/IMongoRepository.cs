using FlightSchedule.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSchedule.Domain.Interfaces.Repositories
{
    public interface IMongoRepository<T> : IDisposable where T : Entity
    {
        Task<T> AddAsync(T model, CancellationToken cancellationToken);
        Task<long> UpdateAsync(Expression<Func<T, bool>> filter, UpdateDefinition<T> update, CancellationToken cancellationToken);
        Task<T> FindByIdAsync(string id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> AllAsync(CancellationToken cancellationToken);
        Task<long> DeleteByIdAsync(string id, CancellationToken cancellationToken);
        Task<long> DeleteAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task<long> CountAsync(Expression<Func<T, bool>> filter);
        Task<long> ReplaceOneAsync(T model, CancellationToken cancellationToken);
    }
}

using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSchedule.Infra.Data.Repositories
{
    public abstract class MongoRepository<TEntity> : IMongoRepository<TEntity> where TEntity : Entity
    {
        #region Protected members
        protected IMongoContextBase dataContext;
        protected IMongoCollection<TEntity> Collection => dataContext.GetCollection<TEntity>();

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                dataContext = null;
        }
        #endregion

        #region Public members
        public async Task<TEntity> AddAsync(TEntity model, CancellationToken cancellationToken)
        {
            await Collection.InsertOneAsync(model, cancellationToken: cancellationToken);
            return model;
        }
        public async Task<long> UpdateAsync(Expression<Func<TEntity, bool>> filter, UpdateDefinition<TEntity> update, CancellationToken cancellationToken)
        {
            var result = await Collection.UpdateManyAsync(filter, update, cancellationToken: cancellationToken);
            return result.ModifiedCount;
        }
        public async Task<TEntity> FindByIdAsync(string id)
        {
            var result = await Collection.FindAsync(x => x.Id == id);
            return result.FirstOrDefault();
        }
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = await Collection.FindAsync(filter);
            return result.ToEnumerable();
        }
        
        public async Task<IEnumerable<TEntity>> AllAsync(CancellationToken cancellationToken)
        {
            var result = await Collection.FindAsync(_ => true);
            return result.ToEnumerable(cancellationToken);
        }
        public async Task<long> DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {
            var result = await Collection.DeleteOneAsync(x => x.Id == id, cancellationToken);
            return result.DeletedCount;
        }
        public async Task<long> DeleteAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            var result = await Collection.DeleteManyAsync(filter, cancellationToken);
            return result.DeletedCount;
        }
        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> filter) => await Collection.CountDocumentsAsync(filter);

        public async Task<long> ReplaceOneAsync(TEntity model, CancellationToken cancellationToken)
        {
            var result = await Collection.ReplaceOneAsync(x => x.Id == model.Id, model, cancellationToken: cancellationToken);
            return result.ModifiedCount;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Domain.Interfaces.Repositories
{
    public interface IMongoContextBase
    {
        string ConnectionString { get; }
        MongoUrl Url { get; }
        MongoClient Client { get; }
        IMongoDatabase Database { get; }
        string GetCollectionName<TEntity>();
        IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName);
        IMongoCollection<TEntity> GetCollection<TEntity>();
    }
}

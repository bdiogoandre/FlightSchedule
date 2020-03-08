using FlightSchedule.Domain.Interfaces.Repositories;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Infra.Data.Context
{
    public abstract class MongoContextBase : IMongoContextBase
    {
        private readonly string _connectionString;
        public MongoContextBase(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException(nameof(connectionString));

            _connectionString = connectionString;

            MongoGlobalOptions.Init();
        }
        public string ConnectionString => _connectionString;
        public MongoUrl Url => new MongoUrl(_connectionString);
        public MongoClient Client => new MongoClient(Url);
        public IMongoDatabase Database => Client.GetDatabase("case-engineering");
        public string GetCollectionName<TEntity>()
        {
            if(Attribute.GetCustomAttribute(typeof(TEntity), typeof(BsonDiscriminatorAttribute)) != null)
            {
                var cm = BsonClassMap.LookupClassMap(typeof(TEntity));
                if (!string.IsNullOrWhiteSpace(cm.Discriminator))
                    return cm.Discriminator;
            }
            var name = typeof(TEntity).Name;
            if (MongoGlobalOptions.EnableCamelCaseCollectionName)
                name = char.ToLower(name[0]) + name.Substring(1);

            return name;
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>(string collectioName) => Database.GetCollection<TEntity>(collectioName);
        public IMongoCollection<TEntity> GetCollection<TEntity>() => Database.GetCollection<TEntity>(GetCollectionName<TEntity>());
    }
}

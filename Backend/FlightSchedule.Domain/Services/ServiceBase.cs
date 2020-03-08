using AutoMapper;
using FlightSchedule.Domain.Entities;
using FlightSchedule.Domain.Entities.Enums;
using FlightSchedule.Domain.Interfaces.Repositories;
using FlightSchedule.Domain.Interfaces.Services;
using FlightSchedule.Domain.Models;
using FlightSchedule.Domain.Models.Request;
using FlightSchedule.Domain.Models.Response;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSchedule.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entity
    {
        protected IMapper _mapper;
        private readonly IMongoRepository<TEntity> _repositoryBase;

        public ServiceBase(IMongoRepository<TEntity> repositoryBase, IMapper mapper)
        {
            _mapper = mapper;
            _repositoryBase = repositoryBase;
        }
        public async Task<Result<string>> AddAsync<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : BaseRequest
        {
            if (request == null)
                return new Result<string>(string.Empty, HttpStatusCode.BadRequest, problemTittle: "Object is null");

            TEntity objEntity;
            try
            {
                objEntity = _mapper.Map<TRequest, TEntity>(request);
            }
            catch(AutoMapperMappingException ex)
            {
                return new Result<string>(string.Empty, HttpStatusCode.BadRequest, problemDetail: ex.InnerException.Message);
            }

            if (!objEntity.IsValid(EValidationStage.Insert))
                return new Result<string>(string.Empty, HttpStatusCode.BadRequest, errors: objEntity.Errors);

            try
            {
                objEntity = await _repositoryBase.AddAsync(objEntity, cancellationToken);
            }
            catch (Exception)
            {
                return new Result<string>(string.Empty, HttpStatusCode.InternalServerError, problemDetail: $"Error on create object {typeof(TEntity).Name}.");
            }
            return new Result<string>(objEntity.Id, HttpStatusCode.Created);

        }
        public async Task<Result<long>> UpdateAsync(Expression<Func<TEntity, bool>> filter, UpdateDefinition<TEntity> update, CancellationToken cancellationToken)
        {
            if(filter == null)
                return new Result<long>(0, HttpStatusCode.BadRequest, problemTittle: "Filter cannot be null");

            long affected;
            try
            {
                affected = await _repositoryBase.UpdateAsync(filter, update, cancellationToken);
            }
            catch (Exception)
            {
                return new Result<long>(0, HttpStatusCode.InternalServerError, problemDetail: $"Error on update object {typeof(TEntity).Name}.");
            }
            return new Result<long>(affected, HttpStatusCode.OK);
        }
        public async Task<Result<TResponse>> GetByIdAsync<TResponse>(string id) where TResponse : BaseResponse
        {
            if (string.IsNullOrWhiteSpace(id))
                return new Result<TResponse>(null, HttpStatusCode.BadRequest, problemTittle: "Id cannot be null or empty");

            TEntity objEntity;
            try
            {
                objEntity = await _repositoryBase.FindByIdAsync(id);
            }
            catch (Exception)
            {
                return new Result<TResponse>(null, HttpStatusCode.InternalServerError, problemTittle: $"Error on get object {typeof(TEntity).Name}.");
            }

            var response = _mapper.Map<TEntity, TResponse>(objEntity);

            return new Result<TResponse>(response, HttpStatusCode.OK);
        }
        public async Task<Result<IEnumerable<TResponse>>> GetAsync<TResponse>(Expression<Func<TEntity, bool>> filter) where TResponse : BaseResponse
        {
            if (filter == null)
                return new Result<IEnumerable<TResponse>>(null, HttpStatusCode.BadRequest, problemTittle: "Filter cannot be null");

            IEnumerable<TEntity> objEntities;
            try
            {
                objEntities = await _repositoryBase.FindAsync(filter);
            }
            catch (Exception)
            {
                return new Result<IEnumerable<TResponse>>(null, HttpStatusCode.InternalServerError, problemTittle: $"Error on get objects {typeof(TEntity).Name}.");
            }

            var response = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(objEntities);

            return new Result<IEnumerable<TResponse>>(response, HttpStatusCode.OK);
        }
        public async Task<Result<IEnumerable<TResponse>>> AllAsync<TResponse>(CancellationToken cancellationToken) where TResponse : BaseResponse
        {
            IEnumerable<TEntity> objEntities;
            try
            {
                objEntities = await _repositoryBase.AllAsync(cancellationToken);
            }
            catch (Exception)
            {
                return new Result<IEnumerable<TResponse>>(null, HttpStatusCode.InternalServerError, problemTittle: $"Error on get all objects {typeof(TEntity).Name}.");
            }

            var response = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(objEntities);

            return new Result<IEnumerable<TResponse>>(response, HttpStatusCode.OK);
        }
        public async Task<Result<long>> DeleteByIdAsync(string id, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(id))
                return new Result<long>(0, HttpStatusCode.BadRequest, problemTittle: "Id cannot be null or empty");

            long affected;
            try
            {
                affected = await _repositoryBase.DeleteByIdAsync(id, cancellationToken);
            }
            catch (Exception)
            {
                return new Result<long>(0, HttpStatusCode.InternalServerError, problemTittle: $"Error on delete object {typeof(TEntity).Name}.");
            }

            return new Result<long>(affected, HttpStatusCode.OK);
        }
        public async Task<Result<long>> DeleteAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            if (filter == null)
                return new Result<long>(0, HttpStatusCode.BadRequest, problemTittle: "Filter cannot be null");

            long affected;
            try
            {
                affected = await _repositoryBase.DeleteAsync(filter, cancellationToken);
            }
            catch (Exception)
            {
                return new Result<long>(0, HttpStatusCode.InternalServerError, problemTittle: $"Error on delete objects {typeof(TEntity).Name}.");
            }

            return new Result<long>(affected, HttpStatusCode.OK);
        }
        public async Task<Result<long>> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
                return new Result<long>(0, HttpStatusCode.BadRequest, problemTittle: "Filter cannot be null");

            long count;
            try
            {
                count = await _repositoryBase.CountAsync(filter);
            }
            catch (Exception)
            {
                return new Result<long>(0, HttpStatusCode.InternalServerError, problemTittle: $"Error on count objects {typeof(TEntity).Name}.");
            }

            return new Result<long>(count, HttpStatusCode.OK);
        }
        public async Task<Result<long>> ReplaceOneAsync<TRequest>(TRequest request, CancellationToken cancellationToken) where TRequest : BaseRequest
        {
            if (request == null)
                return new Result<long>(0, HttpStatusCode.BadRequest, problemTittle: "Object is null");

            TEntity objEntity;
            try
            {
                objEntity = _mapper.Map<TRequest, TEntity>(request);
            }
            catch (AutoMapperMappingException ex)
            {
                return new Result<long>(0, HttpStatusCode.BadRequest, problemDetail: ex.InnerException.Message);
            }

            if (!objEntity.IsValid(EValidationStage.Update))
                return new Result<long>(0, HttpStatusCode.BadRequest, errors: objEntity.Errors);

            long affected;
            try
            {
                affected = await _repositoryBase.ReplaceOneAsync(objEntity, cancellationToken);
            }
            catch (Exception)
            {
                return new Result<long>(0, HttpStatusCode.InternalServerError, problemTittle: $"Error on update object {typeof(TEntity).Name}.");
            }

            return new Result<long>(affected, HttpStatusCode.OK);
        }
    }
}

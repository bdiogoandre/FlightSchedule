using FlightSchedule.Domain.Entities.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Domain.Entities
{
    public abstract class Entity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime UltimaAlteracao { get; set; }

        protected Entity()
        {
            CriadoEm = DateTime.Now.ToUniversalTime();
            UltimaAlteracao = DateTime.Now.ToUniversalTime();
            Errors = new List<Dictionary<string, List<string>>>();
        }
        public abstract bool IsValid(EValidationStage eValidationStage);

        [BsonIgnore]
        public List<Dictionary<string, List<string>>> Errors { get; set; }
    }
}

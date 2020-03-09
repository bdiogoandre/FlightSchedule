using FlightSchedule.Domain.Entities.Enums;
using FlightSchedule.Domain.Models;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Domain.Entities
{
    public class FlightScheduleModel : Entity
    {
        [BsonIgnoreIfNull]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Nome { get; set; }

        [BsonIgnoreIfNull]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DataHoraPartida { get; set;}

        [BsonIgnoreIfNull]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Origem { get; set; }

        [BsonIgnoreIfNull]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Destino { get; set; }

        public override bool IsValid(EValidationStage eValidationStage)
        {
            bool validationResult = true;
            if(eValidationStage == EValidationStage.Insert)
            {
               
                if (string.IsNullOrWhiteSpace(Nome))
                {
                    Errors.Add(ProblemsDetail.GenerateError(nameof(Nome), "Cannot be null or empty"));
                    validationResult = false;
                }

                if(DataHoraPartida.CompareTo(DateTime.Now) < 0)
                {
                    Errors.Add(ProblemsDetail.GenerateError(nameof(DataHoraPartida), "A data e hora de partida não pode ser menor do que a data e hora atual"));
                    validationResult = false;
                }

                if (string.IsNullOrWhiteSpace(Origem))
                {
                    Errors.Add(ProblemsDetail.GenerateError(nameof(Origem), "Cannot be null or empty"));
                    validationResult = false;
                }

                if (string.IsNullOrWhiteSpace(Destino))
                {
                    Errors.Add(ProblemsDetail.GenerateError(nameof(Destino), "Cannot be null or empty"));
                    validationResult = false;
                }
            }

            if (eValidationStage == EValidationStage.Update)
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    Errors.Add(ProblemsDetail.GenerateError(nameof(Id), "Cannot be null or empty"));
                    validationResult = false;
                }
                if (string.IsNullOrWhiteSpace(Nome))
                {
                    Errors.Add(ProblemsDetail.GenerateError(nameof(Nome), "Cannot be null or empty"));
                    validationResult = false;
                }
                if (DataHoraPartida.CompareTo(DateTime.Now) < 0)
                {
                    Errors.Add(ProblemsDetail.GenerateError(nameof(DataHoraPartida), "A data e hora de partida não pode ser a data e hora atual"));
                    validationResult = false;
                }
                if (string.IsNullOrWhiteSpace(Origem))
                {
                    Errors.Add(ProblemsDetail.GenerateError(nameof(Origem), "Cannot be null or empty"));
                    validationResult = false;
                }
                if (string.IsNullOrWhiteSpace(Destino))
                {
                    Errors.Add(ProblemsDetail.GenerateError(nameof(Destino), "Cannot be null or empty"));
                    validationResult = false;
                }
            }

            if (eValidationStage == EValidationStage.Delete)
            {
                if (string.IsNullOrWhiteSpace(Id))
                {
                    Errors.Add(ProblemsDetail.GenerateError(nameof(Id), "Cannot be null"));
                    validationResult = false;
                }
            }

            return validationResult;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tothdev.Placemap.API.DTO;
using Tothdev.Placemap.Entity;

namespace Tothdev.Placemap.API.Code
{
    public class EntityMapper
    {
        public static SurveyResponseAnswerDTO ResponseAnswerToDto(SurveyResponseAnswer entity)
        {
            SurveyResponseAnswerDTO dto = new SurveyResponseAnswerDTO()
            {
                Id = entity.Id,
                AnswerText = entity.AnswerText,
                AnswerValue = entity.AnswerValue,
                CheckBoxOptions = !string.IsNullOrEmpty(entity.ResponseOptionJson) ? JsonConvert.DeserializeObject<List<string>>(entity.ResponseOptionJson) : null,
                SurveyItem = entity.SurveyItem,
                ItemType = entity.SurveyItem.SurveyItemType.Name,
            };

            switch (entity.SurveyItem.SurveyItemType.Name)
            {
                case "radio":
                    dto.RadioOptionSelected = entity.SurveyItem.Options.FirstOrDefault(i => entity.AnswerText == i.OptionValue.ToString());
                    break;
                case "checkbox":

                    break;
            }

            return dto;
        }
        public static SurveyResponseDTO ResponseToDto(SurveyResponse entity)
        {
            SurveyResponseDTO dto = new SurveyResponseDTO()
            {
                SurveyResponseAnswers = entity.SurveyResponseAnswers.Select(i=>ResponseAnswerToDto(i)).ToList(),
                Id = entity.Id,
                InsertDate = entity.InsertDate,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude
            };

            var responseThatDeterminesColor = entity.SurveyResponseAnswers.FirstOrDefault(i => i.SurveyItem.DeterminesMarkerColor);

            if (responseThatDeterminesColor != null)
            {
                switch (responseThatDeterminesColor.AnswerText)
                {
                    case "1":
                        dto.MarkerColor = "red";
                        break;
                    case "2":
                        dto.MarkerColor = "yellow";
                        break;
                    case "3":
                        dto.MarkerColor = "green";
                        break;
                }
            }

            return dto;
        }
    }
}
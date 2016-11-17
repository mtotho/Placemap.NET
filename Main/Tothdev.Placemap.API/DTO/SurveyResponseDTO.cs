using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tothdev.Placemap.Entity;

namespace Tothdev.Placemap.API.DTO
{
    public class SurveyResponseDTO
    {
        public int Id { get; set; }
        public List<SurveyResponseAnswerDTO> SurveyResponseAnswers { get; set; }
        public string MarkerColor { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
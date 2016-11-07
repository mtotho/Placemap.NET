using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Entity
{
    public class SurveyResponse
    {
        public int Id { get; set; }
        public List<SurveyResponseAnswer> SurveyResponseAnswers { get; set; }
        public int PlacemapSurveyId { get; set; }
        public PlacemapSurvey PlacemapSurvey { get; set; }
        public int PlaceId { get; set; }
        public Place Place { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string ApprovalStatus { get; set; }
        public string BrowserAndVersion { get; set; }
        public string SessionKey { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Entity
{
    public class SurveyItem
    {
        public int Id { get; set; }
        public string ItemText { get; set; }
        public bool Required { get; set; }
        public int? MinimumValue { get; set; }
        public int? MaximumValue { get; set; }
        public bool HigherIsBetter { get; set; }
        public int PlaceMapSurveyId { get; set; }
        public PlacemapSurvey PlacemapSurvey { get; set; }
        public int SurveyItemTypeId { get; set; }
        public SurveyItemType SurveyItemType { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

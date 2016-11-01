using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Entity
{
    public class SurveyResponseAnswer
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int? AnswerValue { get; set; }
        public string ResponseOptionJson { get; set; }
        public int? SurveyItemId { get; set; }
        public SurveyItem SurveyItem { get; set; }
        public int SurveyResponseId { get; set; }
        public SurveyResponse SurveyResponse { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

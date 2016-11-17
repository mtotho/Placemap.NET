using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tothdev.Placemap.Entity;

namespace Tothdev.Placemap.API.DTO
{
    public class SurveyResponseAnswerDTO
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public int? AnswerValue { get; set; }
        public string ItemType { get; set; }
        public SurveyItemOption RadioOptionSelected { get; set; } 
        public List<string> CheckBoxOptions{ get; set; }
        public SurveyItem SurveyItem { get; set; }
   
    }
}
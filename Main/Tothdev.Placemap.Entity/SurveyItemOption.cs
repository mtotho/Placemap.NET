using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Entity
{
    public class SurveyItemOption
    {
        public int Id { get; set; }
        public string OptionValue { get; set; }
        public string OptionText { get; set;}
        public bool IsNumericValue { get; set; }
        public int SurveyItemId { get; set; }
        public SurveyItem SurveyItem { get; set;  }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

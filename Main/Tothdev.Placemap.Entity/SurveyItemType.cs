using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Entity
{
    public class SurveyItemType
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool UseScale { get; set; }
        public bool IsQuestion { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

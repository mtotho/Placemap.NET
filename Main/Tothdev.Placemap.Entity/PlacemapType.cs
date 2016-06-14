using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Entity
{
    public class PlacemapType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

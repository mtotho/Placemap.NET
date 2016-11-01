using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tothdev.Placemap.Entity
{
    public class Place
    {
        public int Id { get; set; }
        public string PlaceKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PlacemapType PlaceType { get; set; }
        public int PlaceTypeId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool IsPublic { get; set; }
        public int DefaultZoom { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

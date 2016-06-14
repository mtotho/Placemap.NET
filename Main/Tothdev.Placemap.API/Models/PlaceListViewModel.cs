using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tothdev.Placemap.Entity;
using Tothdev.Placemap.Repository;

namespace Tothdev.Placemap.API.Models
{
    public class PlaceListViewModel
    {
        public List<Place> Places { get; set; }
        public PlaceListViewModel()
        {

        }

        public static PlaceListViewModel GetDefault()
        {
            PlaceListViewModel vm = new PlaceListViewModel();
            var _db = new PlacemapDBContext();

            vm.Places = _db.Places.Include("PlaceType").Where(i=>i.IsPublic).ToList();

            return vm;
        }
    }
}
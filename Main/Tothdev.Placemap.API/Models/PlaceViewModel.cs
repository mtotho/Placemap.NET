using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tothdev.Placemap.Entity;
using Tothdev.Placemap.Repository;

namespace Tothdev.Placemap.API.Models
{
    public class PlaceViewModel
    {
        public Place Place { get; set; }
        public bool PlaceExists { get; set; }

        public static PlaceViewModel GetDefault(string PlaceKey)
        {
            PlaceViewModel vm = new PlaceViewModel();

            var _db = new PlacemapDBContext();

            vm.Place = _db.Places.Include("PlaceType").FirstOrDefault(i => i.PlaceKey == PlaceKey);
            vm.PlaceExists = vm.Place != null;
            if (!vm.PlaceExists)
                return vm; 



            return vm;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Tothdev.Placemap.Entity;
using Tothdev.Placemap.Repository;

namespace Tothdev.Placemap.API
{
    public class SeedData
    {
        public static void Seed()
        {
            var _db = new PlacemapDBContext();

            var shouldSheed = ConfigurationManager.AppSettings["ShouldSeedData"];
            if (_db.Places.ToList().Count > 0 || shouldSheed == "0")
                return;

            seedPlacemapTypes();

        }

        private static void seedPlacemapTypes()
        {
            var _db = new PlacemapDBContext();

            var placemapType1 = new PlacemapType()
            {
                Code = "DOT",
                DisplayName = "Dot Map",
                Description = "Place a dot on a place of interest",
                InsertDate = DateTime.UtcNow
            };

            var placemapType2 = new PlacemapType()
            {
                Code = "HOTSPOT",
                DisplayName = "Hotspot Survey",
                Description = "Provide feedback on a number of preselected locations",
                InsertDate = DateTime.UtcNow
            };

            _db.PlacemapTypes.Add(placemapType1);
            _db.PlacemapTypes.Add(placemapType2);
            _db.SaveChanges();
        }
    }
}
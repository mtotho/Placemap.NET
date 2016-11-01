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



            var surveyItemType = new SurveyItemType()
            {
                UseScale = true,
                InsertDate = DateTime.UtcNow,
                IsQuestion = true,
                Name = "likert"
            };

            _db.SurveyItemType.Add(surveyItemType);
            _db.SaveChanges();


            var place1 = new Place()
            {
                City = "Lambertville",
                CountryCode = "US",
                Latitude = 40.3659m,
                Longitude = -74.9429m,
                PostalCode = "08530",
                Description = "Downtown Lambertville",
                Name = "Downtown Lambertville",
                InsertDate = DateTime.UtcNow,
                State = "NJ",
                PlaceTypeId = placemapType1.Id,
                IsPublic = true,
                PlaceKey = "LVILLE",
                DefaultZoom = 12
            };

            _db.Places.Add(place1);
            _db.SaveChanges();
        }
    }
}
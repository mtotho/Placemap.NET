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



            var surveyItemTypeLikert = new SurveyItemType()
            {
                UseScale = true,
                InsertDate = DateTime.UtcNow,
                IsQuestion = true,
                Name = "likert"
            };

            var surveyItemTypeCheckBox = new SurveyItemType()
            {
                InsertDate = DateTime.UtcNow,
                IsQuestion = true,
                Name = "checkbox"
            };
            var surveyItemTypeRadio = new SurveyItemType()
            {
                InsertDate = DateTime.UtcNow,
                IsQuestion = true,
                Name = "radio"
            };
            var surveyItemTypeShortAnswer = new SurveyItemType()
            {
                InsertDate = DateTime.UtcNow,
                IsQuestion = true,
                Name = "shortanswer"
            };

            _db.SurveyItemTypes.Add(surveyItemTypeLikert);
            _db.SurveyItemTypes.Add(surveyItemTypeRadio);
            _db.SurveyItemTypes.Add(surveyItemTypeCheckBox);
            _db.SurveyItemTypes.Add(surveyItemTypeShortAnswer);
            _db.SaveChanges();


            var survey1 = new PlacemapSurvey()
            {
                Name = "Sample Survey",
                Description = "Sample Survey",
                InsertDate = DateTime.UtcNow,
            };

            _db.PlacemapSurveys.Add(survey1);
            _db.SaveChanges();

            //var surveyitem1 = new SurveyItem()
            //{
            //    HigherIsBetter = true,
            //    PlaceMapSurveyId = survey1.Id,
            //    SurveyItemTypeId = surveyItemTypeLikert.Id,
            //    InsertDate = DateTime.UtcNow,
            //    MaximumValue = 5,
            //    MinimumValue = 1,
            //    Required = true,
            //    ItemText = "Likely to return to this location."
            //};


            var surveyitem1 = new SurveyItem()
            {
                HigherIsBetter = true,
                PlaceMapSurveyId = survey1.Id,
                SurveyItemTypeId = surveyItemTypeRadio.Id,
                DeterminesMarkerColor = true,
                InsertDate = DateTime.UtcNow,
                Required = true,
                ItemText = "Does this place add or subtract value to your community",
                Options = new List<SurveyItemOption>()
                {
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Detracts from community",
                        OptionValue = "1",
                        IsNumericValue = true,
                    },
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Important opportunity that needs work",
                        OptionValue = "2",
                        IsNumericValue = true,
                    },
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "A cool place that adds value",
                        OptionValue = "3",
                        IsNumericValue = true,
                    }
                }
            };


            var surveyitem2 = new SurveyItem()
            {
                HigherIsBetter = true,
                PlaceMapSurveyId = survey1.Id,
                SurveyItemTypeId = surveyItemTypeCheckBox.Id,
                InsertDate = DateTime.UtcNow,
                Required = true,
                ItemText = "What kind of place?",
                Options = new List<SurveyItemOption>()
                {
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Intersection",
                        OptionValue = "Intersection",
                        IsNumericValue = false,
                    },
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Park",
                        OptionValue = "Park",
                        IsNumericValue = false,
                    },
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Tourist attraction",
                        OptionValue = "Tourist attraction",
                        IsNumericValue = false,
                    },
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Plaza",
                        OptionValue = "Plaza",
                        IsNumericValue = false,
                    },
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Public institution (library, school, post office)",
                        OptionValue = "Public institution (library, school, post office)",
                        IsNumericValue = false,
                    },
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Cluster of shops, stores",
                        OptionValue = "Cluster of shops, stores",
                        IsNumericValue = false,
                    },
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Scenic area",
                        OptionValue = "Scenic area",
                        IsNumericValue = false,
                    },
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Health care",
                        OptionValue = "Health care",
                        IsNumericValue = false,
                    },
                    new SurveyItemOption()
                    {
                        InsertDate = DateTime.UtcNow,
                        OptionText = "Historic site",
                        OptionValue = "Historic site",
                        IsNumericValue = false,
                    }
                }
            };


            var surveyitem4 = new SurveyItem()
            {
                HigherIsBetter = true,
                PlaceMapSurveyId = survey1.Id,
                SurveyItemTypeId = surveyItemTypeShortAnswer.Id,
                InsertDate = DateTime.UtcNow,
                Required = true,
                ItemText = "Can you tell us a little bit more about this location?"
            };

            _db.SurveyItems.Add(surveyitem1);
            _db.SurveyItems.Add(surveyitem2);
            _db.SurveyItems.Add(surveyitem4);
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
                PlacemapSurveyId = survey1.Id,
                PlaceTypeId = placemapType1.Id,
                IsPublic = true,
                PlaceKey = "LVILLE",
                DefaultZoom = 15,
                ShowResponses = true
            };

            var place2 = new Place()
            {
                City = "Bozeman",
                CountryCode = "US",
                Latitude = 45.679298m,
                Longitude = -111.046275m,
                PostalCode = "59715",
                Description = "Downtown Bozeman",
                Name = "Downtown Bozeman",
                InsertDate = DateTime.UtcNow,
                State = "MT",
                PlacemapSurveyId = survey1.Id,
                PlaceTypeId = placemapType1.Id,
                IsPublic = true,
                PlaceKey = "BOZE",
                DefaultZoom = 15,
                ShowResponses = true
            };

            var place3 = new Place()
            {
                City = "Forth Worth",
                CountryCode = "US",
                Latitude = 32.732780m,
                Longitude = -97.331572m,
                PostalCode = "59715",
                Description = "Hemphill St",
                Name = "Hemphill St, Fort Worth",
                InsertDate = DateTime.UtcNow,
                State = "TX",
                PlacemapSurveyId = survey1.Id,
                PlaceTypeId = placemapType1.Id,
                IsPublic = true,
                PlaceKey = "HEMPHILL",
                DefaultZoom = 15,
                ShowResponses = false
            };

            _db.Places.Add(place1);
            _db.Places.Add(place2);
            _db.Places.Add(place3);
            _db.SaveChanges();

        }
    }
}
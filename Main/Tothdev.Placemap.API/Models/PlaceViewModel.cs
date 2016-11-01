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
        public SurveyResponse SurveyResponse { get; set; }

        public static PlaceViewModel GetDefault(string PlaceKey)
        {
            PlaceViewModel vm = new PlaceViewModel();

            var _db = new PlacemapDBContext();

            vm.Place = _db.Places
                .Include("PlaceType")
                .Include("PlacemapSurvey")
                .Include("PlacemapSurvey.SurveyItems")
                .Include("PlacemapSurvey.SurveyItems.SurveyItemType")
                .FirstOrDefault(i => i.PlaceKey == PlaceKey);
            vm.PlaceExists = vm.Place != null;
            if (!vm.PlaceExists)
                return vm;

            vm.SurveyResponse = new SurveyResponse()
            {
                PlacemapSurveyId = vm.Place.PlacemapSurveyId,
                PlaceId = vm.Place.Id,
                SurveyResponseAnswers = new List<SurveyResponseAnswer>()
            };

            foreach(SurveyItem item in vm.Place.PlacemapSurvey.SurveyItems)
            {
                vm.SurveyResponse.SurveyResponseAnswers.Add(new SurveyResponseAnswer()
                {
                    SurveyItemId = item.Id,
                });
            }

            return vm;
        }
    }
}
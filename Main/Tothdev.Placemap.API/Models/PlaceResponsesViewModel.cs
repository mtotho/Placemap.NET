using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tothdev.Placemap.API.Code;
using Tothdev.Placemap.API.DTO;
using Tothdev.Placemap.Entity;
using Tothdev.Placemap.Repository;

namespace Tothdev.Placemap.API.Models
{
    public class PlaceResponsesViewModel
    {
        public Place Place { get; set; }
        public bool PlaceExists { get; set; }
        public List<SurveyResponseDTO> Responses { get; set; }
        public static PlaceResponsesViewModel GetDefault(string PlaceKey)
        {
            PlaceResponsesViewModel vm = new PlaceResponsesViewModel();

            var _db = new PlacemapDBContext();

            vm.Place = _db.Places
                .Include("PlaceType")
                .Include("PlacemapSurvey")
                .Include("PlacemapSurvey.SurveyItems")
                .Include("PlacemapSurvey.SurveyItems.Options")
                .Include("PlacemapSurvey.SurveyItems.SurveyItemType")
                .FirstOrDefault(i => i.PlaceKey == PlaceKey);
            vm.PlaceExists = vm.Place != null;
            if (!vm.PlaceExists)
                return vm;


            vm.Responses = _db.SurveyResponses
                 .Include("SurveyResponseAnswers")
                 .Include("SurveyResponseAnswers.SurveyItem")
                 .Where(i => i.PlaceId == vm.Place.Id && i.PlacemapSurveyId == vm.Place.PlacemapSurveyId)
                 .ToList()
                 .Select(i => EntityMapper.ResponseToDto(i))
                 .ToList();

            return vm;
        }

    }
}
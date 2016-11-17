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
    public class PlaceViewModel
    {
        public Place Place { get; set; }
        public bool PlaceExists { get; set; }
        public SurveyResponse SurveyResponse { get; set; }
        public List<SurveyResponseDTO> Responses { get; set; }
        public static PlaceViewModel GetDefault(string PlaceKey, string SessionKey)
        {
            PlaceViewModel vm = new PlaceViewModel();

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

            vm.Responses = new List<SurveyResponseDTO>();

            if (vm.Place.ShowResponses)
            {
                vm.Responses = _db.SurveyResponses
                    .Include("SurveyResponseAnswers")
                    .Include("SurveyResponseAnswers.SurveyItem")
                    .Where(i => i.PlaceId == vm.Place.Id && i.PlacemapSurveyId == vm.Place.PlacemapSurveyId)
                    .ToList()
                    .Select(i => EntityMapper.ResponseToDto(i))
                    .ToList();
            }else if (vm.Place.CanSeeOwnResponses && !string.IsNullOrEmpty(SessionKey))
            {
                vm.Responses = _db.SurveyResponses
                    .Include("SurveyResponseAnswers")
                    .Include("SurveyResponseAnswers.SurveyItem")
                    .Where(i => i.PlaceId == vm.Place.Id && i.PlacemapSurveyId == vm.Place.PlacemapSurveyId && i.SessionKey == SessionKey)
                    .ToList()
                    .Select(i => EntityMapper.ResponseToDto(i))
                    .ToList();
            }

            return vm;
        }

    }
}
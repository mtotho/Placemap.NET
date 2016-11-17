using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Tothdev.Placemap.API.Models;

namespace Tothdev.Placemap.API.VmControllers
{
    [EnableCors(origins: "http://localhost:1337", headers: "*", methods: "*")]
    [RoutePrefix("vm/Place")]
    public class PlaceController : ApiController
    {
        [HttpGet]
        [Route("GetViewModel")]
        public PlaceViewModel GetViewModel(string PlaceKey)
        {
            var sessionKey = Request.Headers.FirstOrDefault(i => i.Key == "SESSIONKEY");
            var sessionKeyString = sessionKey.Key != null ? sessionKey.Value.FirstOrDefault() : "";

            PlaceViewModel vm = PlaceViewModel.GetDefault(PlaceKey, sessionKeyString);
            return vm;
        }

        [HttpGet]
        [Route("GetResponseViewModel")]
        public PlaceResponsesViewModel GetResponseViewModel(string PlaceKey)
        {
            PlaceResponsesViewModel vm = PlaceResponsesViewModel.GetDefault(PlaceKey);
            return vm;
        }
    }
}
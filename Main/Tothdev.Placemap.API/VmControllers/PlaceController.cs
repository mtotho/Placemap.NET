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
            PlaceViewModel vm = PlaceViewModel.GetDefault(PlaceKey);
            return vm;
        }
    }
}
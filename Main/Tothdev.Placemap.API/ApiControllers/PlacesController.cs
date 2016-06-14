using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Tothdev.Placemap.Entity;
using Tothdev.Placemap.Repository;

namespace Tothdev.Placemap.API.ApiControllers
{
    [RoutePrefix("api/Places")]
    public class PlacesController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public List<Place> Get()
        {
            var _db = new PlacemapDBContext();

            return _db.Places.Include("PlaceType").ToList();
        }
    }
}
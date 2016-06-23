using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Tothdev.Placemap.Entity;
using Tothdev.Placemap.Repository;

namespace Tothdev.Placemap.API.ApiControllers
{
    [EnableCors(origins: "http://localhost:1337", headers: "*", methods: "*")]
    [RoutePrefix("api/Places")]
    public class PlacesController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public List<Place> Get()
        {
            var _db = new PlacemapDBContext();
            var query = _db.Places.Include("PlaceType").AsQueryable();


            return query.ToList();
        }
    }
}
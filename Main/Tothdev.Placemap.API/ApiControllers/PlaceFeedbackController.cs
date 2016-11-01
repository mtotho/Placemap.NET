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
    [RoutePrefix("api/PlaceFeedback")]
    public class PlaceFeedbackController : ApiController
    {
        [HttpPost]
        [Route("Post")]
        public bool Post(SurveyResponse response)
        {
            var _db = new PlacemapDBContext();

            response.InsertDate = DateTime.UtcNow;
            _db.SurveyResponses.Add(response);

            _db.SaveChanges();

            return true;
        }
    }
}
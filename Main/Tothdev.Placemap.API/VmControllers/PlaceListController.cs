﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Tothdev.Placemap.API.Models;

namespace Tothdev.Placemap.API.VmControllers
{
    [EnableCors(origins: "http://localhost:1337", headers: "*", methods: "*")]
    [RoutePrefix("vm/PlaceList")]
    public class PlaceListController : ApiController
    {
        [HttpGet]
        [Route("GetViewModel")]
        public PlaceListViewModel GetViewModel()
        {
            PlaceListViewModel vm = PlaceListViewModel.GetDefault();
            return vm;
        }
    }
}
using Leads.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Leads.RESTAPI.Controllers
{
    public class CacheController : ApiController
    {
        private readonly ILeadsService _service;
        public CacheController(ILeadsService service)
        {
            _service = service;
        }

        public HttpResponseMessage Post()
        {
            _service.Clear();
            var response = new HttpResponseMessage();
            response.Content = new StringContent("Cache cleared successfully");
            return response;
        }
    }
}
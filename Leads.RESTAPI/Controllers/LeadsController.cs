using Leads.Core.Exceptions;
using Leads.Core.Models;
using Leads.Core;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Leads.RESTAPI.Controllers
{
    public class LeadsController : ApiController
    {
        private readonly ILeadsService _service;
        private readonly ILogger _logger;
        public LeadsController(ILeadsService service,
            ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        public IList<LeadsModel> Get()
        {
            return _service.GetLeads();
        }

        public IHttpActionResult Get(Guid id)
        {
            try
            {
                var lead = _service.GetLead(id);
                return Ok(lead);
            }
            catch (LeadNotFoundException exception)
            {
                _logger.Error(exception, $"Lead id - {id} not found");
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody] LeadsModel lead)
        {
            try
            {
                _service.InsertNewLead(lead);
                return Ok();
            }
            catch (InvalidLeadException exception)
            {
                _logger.Error(exception, "Invalid lead model");
                return BadRequest(exception.ToString());
            }
        }

    }
}

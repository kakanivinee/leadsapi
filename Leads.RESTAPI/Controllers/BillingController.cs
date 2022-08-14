using Leads.Core.Models;
using Leads.Core;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Leads.RESTAPI.Controllers
{
    public class BillingController : ApiController
    {
        private readonly ILeadsReportService _service;
        private readonly ILogger _logger;
        public BillingController(ILeadsReportService service,
            ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        public IList<PurchasedLeads> GetAll()
        {
            _logger.Information("Computing billing report");
            var report = _service.GetPurchasedLeadsReport();
            _logger.Information("Report created successfully");
            return report.ToList();
        }
    }
}
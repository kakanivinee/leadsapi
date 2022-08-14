using Leads.Core.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Core
{
    public interface ILeadsReportService
    {
        IList<PurchasedLeads> GetPurchasedLeadsReport();
    }

    public class LeadsReportService : ILeadsReportService, IDisposable
    {
        private bool disposedValue;
        private readonly ILeadsService _service;
        private readonly ILogger _logger;
        public LeadsReportService(ILeadsService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        public IList<PurchasedLeads> GetPurchasedLeadsReport()
        {
            _logger.Information("Starting PurchasedLeads report");
            var purchasedLeads = _service.GetLeads()
                .GroupBy(x => x.Provider)
                .Select(x => new PurchasedLeads
                {
                    LeadsProvided = x.Count(),
                    Provider = x.First().Provider
                });
            _logger.Information("returning report");
            return purchasedLeads.ToList();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

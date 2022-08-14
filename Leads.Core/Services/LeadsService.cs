using System;
using System.Linq;
using System.Collections.Generic;
using Leads.Core.Models;
using Serilog;

namespace Leads.Core
{
    public interface ILeadsService
    {
        void InsertNewLead(LeadsModel model);
        IList<LeadsModel> GetLeads();
        LeadsModel GetLead(Guid id);
        void Clear();
    }

    public class LeadsService : ILeadsService, IDisposable
    {
        private readonly IList<LeadsModel> Leads;
        private readonly INotificationService _notificationService;
        private readonly ILogger _logger;
        private bool disposedValue;

        public LeadsService(INotificationService notificationService,
            ILogger logger)
        {
            Leads = new List<LeadsModel>();
            _notificationService = notificationService;
            _logger = logger;
        }

        public void InsertNewLead(LeadsModel lead)
        {
            _logger.Information("Starting Insert Lead operation");
            lead.Validate();
            _logger.Information("Validation completed");
            lead.Id = Guid.NewGuid();
            Leads.Add(lead);
            _logger.Information("Insert completed");
            _notificationService.NotifyLead(lead);
            _logger.Information("Notification triggered");
        }

        public IList<LeadsModel> GetLeads()
        {
            return Leads.ToList();
        }

        public LeadsModel GetLead(Guid id)
        {
            _logger.Information("Starting Find Lead by Id");
            if (Leads.Any(x => x.Id == id))
            {
                _logger.Information("Found lead");
                return Leads.First(x => x.Id == id);
            }
            _logger.Error($"Lead not found for id - {id}");
            throw new LeadNotFoundException(id);
        }

        public void Clear()
        {
            _logger.Information("Clearing Leads cache");
            Leads.Clear();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Leads.Clear();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
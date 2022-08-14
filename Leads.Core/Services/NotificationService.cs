using Leads.Core.Models;
using Serilog;
using System;

namespace Leads.Core
{
    public interface INotificationService
    {
        bool NotifyLead(LeadsModel lead);
    }

    public class NotificationService : INotificationService, IDisposable
    {
        private bool disposedValue;

        private readonly ILogger _logger;

        public NotificationService(ILogger logger)
        {
            _logger = logger;
        }

        public bool NotifyLead(LeadsModel lead)
        {
            if (!lead.HasConsentToContact)
            {
                _logger.Information($"Do not have consent to contact lead - {lead.Name}, skipping the notification");
                return false; //Do not contact lead, no permission
            }

            _logger.Information($"Lead - {lead.Name} has given consent to contact, sending notification");

            //Send email or text to lead...
            return true;
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
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
using Leads.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Core.Models
{
    public class LeadsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public bool HasConsentToContact { get; set; }
        public string Provider { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new InvalidLeadException(Name);
            if (string.IsNullOrWhiteSpace(Phone))
                throw new InvalidLeadException("Invalid phone number");
            if (string.IsNullOrWhiteSpace(Zip))
                throw new InvalidLeadException("Invalid zip");
            if (string.IsNullOrWhiteSpace(Provider))
                throw new InvalidLeadException("Provider cannot be empty");
        }
    }

}

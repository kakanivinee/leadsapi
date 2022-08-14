using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Core
{
    public class LeadNotFoundException : Exception
    {
        public LeadNotFoundException(Guid id) : base($"Lead not found for id - {id}")
        {

        }
    }

}

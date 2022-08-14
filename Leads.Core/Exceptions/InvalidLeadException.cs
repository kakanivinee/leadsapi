using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Core.Exceptions
{
    public class InvalidLeadException : Exception
    {
        public InvalidLeadException(string message) : base(message)
        {

        }
    }
}

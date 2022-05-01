using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Exceptions
{
    public class FoundException : ApplicationException
    {
        public FoundException(string name)
            : base($"Entity \"{name}\" was already exist.")
        {
        }
    }
}

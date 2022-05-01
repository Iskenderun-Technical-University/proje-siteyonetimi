using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.CustomExceptions
{
   
    public class IsExistExeption : Exception
    {
        public IsExistExeption(string message)
             : base($"\"{message}\" ")
        {
        }
    }
}

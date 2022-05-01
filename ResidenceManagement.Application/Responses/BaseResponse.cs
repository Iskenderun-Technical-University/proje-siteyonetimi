using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse(bool success, string message) : this(success)
        {
            Message = message;
        }

        public BaseResponse(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message
        {
            get;

        }
    }
}

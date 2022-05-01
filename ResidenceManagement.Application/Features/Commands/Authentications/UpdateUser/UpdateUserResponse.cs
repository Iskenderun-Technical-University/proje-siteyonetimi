using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Authentications.UpdateUser
{
    public class UpdateUserResponse
    {
        public UpdateUserResponse()
        {
        }

        public UpdateUserResponse(bool succuess, string message)
        {
            Succuess = succuess;
            Message = message;
        }

        public bool Succuess { get; set; }
        public string Message { get; set; }
    }
}

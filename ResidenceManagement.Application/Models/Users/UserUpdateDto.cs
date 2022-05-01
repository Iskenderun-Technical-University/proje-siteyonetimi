using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Models.Users
{
    public class UserUpdateDto :UserDto
    {
        public string Password { get; set; }
    }
}

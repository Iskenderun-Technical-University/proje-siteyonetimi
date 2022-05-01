using Microsoft.AspNetCore.Identity;
using ResidenceManagement.Domain.Entities.Managements;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResidenceManagement.Domain.Entities.Auths
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string CarPlate { get; set; }
        public IEnumerable<UserResidence> UserResidences { get; set; }

        [InverseProperty("Sender")]
        public IEnumerable<Message> Sending { get; set; }

        [InverseProperty("Receiver")]
        public IEnumerable<Message> Receiving { get; set; }

    }
}

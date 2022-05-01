using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Models.Messages
{
    public class GetMessageListDto
    {
        public IReadOnlyList<MessageDto> SendingList { get; set; }
        public IReadOnlyList<MessageDto> RecievingList { get; set; }

    }
}

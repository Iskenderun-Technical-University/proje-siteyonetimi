using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Models.Messages
{
    public class MessageDto
    {
        public string SenderEmail { get; set; }
        public string ReceiverEmail { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
    }
}

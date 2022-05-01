using ResidenceManagement.Application.Contracts.Repositories.Commons;
using ResidenceManagement.Application.Models.Messages;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Contracts.Repositories
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        Task<IReadOnlyList<Message>> GetAllReceiveMessageDetail(int userId);
        Task<IReadOnlyList<Message>> GetAllSendMessageDetail(int userId);


    }
}

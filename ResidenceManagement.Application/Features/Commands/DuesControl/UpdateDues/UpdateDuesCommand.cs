using MediatR;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;

namespace ResidenceManagement.Application.Features.Commands.DuesControl.UpdateDues
{
    public class UpdateDuesCommand : IRequest<BaseDataResponse<Dues>>
    {
        public int Id { get; set; }
        public int Fee { get; set; }
    }
}

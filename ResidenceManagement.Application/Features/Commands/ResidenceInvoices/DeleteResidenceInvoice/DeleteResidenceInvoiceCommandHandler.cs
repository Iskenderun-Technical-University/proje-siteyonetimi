using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceInvoices.DeleteResidenceInvoice
{
    public class DeleteResidenceInvoiceCommandHandler : IRequestHandler<DeleteResidenceInvoiceCommand, BaseResponse>
    {
        private IResidenceInvoiceRepository _residenceInvoiceRepository;

        public DeleteResidenceInvoiceCommandHandler(IResidenceInvoiceRepository residenceInvoiceRepository)
        {
            _residenceInvoiceRepository = residenceInvoiceRepository;
        }

        public async Task<BaseResponse> Handle(DeleteResidenceInvoiceCommand request, CancellationToken cancellationToken)
        {
            var checkResidenceInvoice = await _residenceInvoiceRepository.GetByIdAsync(request.Id);
            if (checkResidenceInvoice == null)
                throw new NotFoundException(request);
            await _residenceInvoiceRepository.RemoveAsync(checkResidenceInvoice);
            return new BaseResponse(true);
        }
    }
}

using AutoMapper;
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

namespace ResidenceManagement.Application.Features.Commands.Invoices.DeleteInvoice
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, BaseResponse>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public DeleteInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<BaseResponse> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            var checkInvoice = await _invoiceRepository.GetByIdAsync(request.Id);
            if (checkInvoice == null)
                throw new NotFoundException(request);
            await _invoiceRepository.RemoveAsync(checkInvoice);
            return new BaseResponse(true);
        }
    }
}

using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Invoices.UpdateInvoice
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, BaseDataResponse<Invoice>>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public UpdateInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<BaseDataResponse<Invoice>> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var checkInvoice = await _invoiceRepository.GetByIdAsync(request.Id);
            if (checkInvoice == null)
                throw new NotFoundException(request);
            checkInvoice.Fee = request.Fee;
            
            await _invoiceRepository.UpdateAsync(checkInvoice);
            return new BaseDataResponse<Invoice>(true, checkInvoice);
        }
    }
}

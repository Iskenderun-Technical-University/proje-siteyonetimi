using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.PaymentControl;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.Invoices.AddInvoice
{
    public class AddInvoiceCommandHandler : IRequestHandler<AddInvoiceCommand, BaseDataResponse<PaymentDto>>
    {
        private IMapper _mapper;
        private IInvoiceRepository _invoiceRepository;

        public AddInvoiceCommandHandler(IMapper mapper, IInvoiceRepository invoiceRepository)
        {
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
        }

        public async Task<BaseDataResponse<PaymentDto>> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
        {
            var checkInvoice =await _invoiceRepository.GetAsync(r=>r.Year == request.Year && r.Month == request.Month);
         
            if (checkInvoice != null)
                throw new NotEmptyException(checkInvoice.Year.ToString() +" "+ checkInvoice.Month.ToString());

           
            await _invoiceRepository.AddAsync(_mapper.Map<Invoice>(request));

            return new BaseDataResponse<PaymentDto>(true, _mapper.Map<PaymentDto>(request)); ;
        }
    }
}

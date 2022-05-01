using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Responses;
using ResidenceManagement.Domain.Entities.Managements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Commands.ResidenceInvoices.AddResidenceInvoice
{
    public class AddResidenceInvoiceCommandHandler : IRequestHandler<AddResidenceInvoiceCommand, BaseResponse>
    {
        private readonly IResidenceInvoiceRepository _residenceInvoiceRepository;
        private readonly IMapper _mapper;

        public AddResidenceInvoiceCommandHandler(IResidenceInvoiceRepository residenceInvoiceRepository, IMapper mapper)
        {
            _residenceInvoiceRepository = residenceInvoiceRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddResidenceInvoiceCommand request, CancellationToken cancellationToken)
        {
            var check =await _residenceInvoiceRepository.GetAsync(r=>r.InvoiceId == request.InvoiceId && r.UserResidenceId == request.UserResidenceId);
            if (check != null)
                throw new NotEmptyException(request.InvoiceId.ToString());
            await _residenceInvoiceRepository.AddAsync(_mapper.Map<ResidenceInvoice>(request));
            return new BaseResponse(true, "Ekleme işlemi başarılı");
        }
    }
}

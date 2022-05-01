using AutoMapper;
using MediatR;
using ResidenceManagement.Application.Contracts.Repositories;
using ResidenceManagement.Application.Exceptions;
using ResidenceManagement.Application.Models.ResidenceInvoices;
using ResidenceManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Features.Queries.ResidenceInvoices.GetUnpaidInvoices
{
    internal class GetUnpaidInvoicesQueryHandler : IRequestHandler<GetUnpaidInvoicesQuery, BaseDataResponse<IReadOnlyList<ResidenceInvoiceDto>>>
    {
        private readonly IResidenceInvoiceRepository _residenceInvoiceRepository;
        private readonly IMapper _mapper;

        public GetUnpaidInvoicesQueryHandler(IResidenceInvoiceRepository residenceInvoiceRepository, IMapper mapper)
        {
            _residenceInvoiceRepository = residenceInvoiceRepository;
            _mapper = mapper;
        }

        public async Task<BaseDataResponse<IReadOnlyList<ResidenceInvoiceDto>>> Handle(GetUnpaidInvoicesQuery request, CancellationToken cancellationToken)
        {
            string[] includes = { "UserResidence", "Invoice", "UserResidence.Residence", "UserResidence.User", "UserResidence.ResidentType" };
            var unpaidInvoiceList = await _residenceInvoiceRepository.GetAllAsync(r => r.IsPaid == false, includeStrings: includes);

            if (unpaidInvoiceList.Count == 0)
                throw new NotFoundException(request);
            var returnList = _mapper.Map<IReadOnlyList<ResidenceInvoiceDto>>(unpaidInvoiceList);
            return new BaseDataResponse<IReadOnlyList<ResidenceInvoiceDto>>(true, returnList);
        }
    }
}

using MassTransit;
using ResidenceManagement.Application.Contracts.Repositories;
using Shared.Models.Models;
using System.Threading.Tasks;

namespace ResidenceManagement.API.Consumers
{
    public class PaymentRangeConsumer : IConsumer<PaymentRangeShareModel>
    {

        private IResidenceDuesRepository _residenceDuesRepository;
        private IResidenceInvoiceRepository _residenceInvoiceRepository;

        public PaymentRangeConsumer(IResidenceDuesRepository residenceDuesRepository, IResidenceInvoiceRepository residenceInvoiceRepository)
        {
            _residenceDuesRepository = residenceDuesRepository;
            _residenceInvoiceRepository = residenceInvoiceRepository;
        }

        public async Task Consume(ConsumeContext<PaymentRangeShareModel> context)
        {
            await Task.Run(async () => {
                var obj = context.Message;
                var paymentType = obj.PaymentType;

                if (paymentType == 1)
                {
                    var idList = obj.PaymentIds;
                    foreach (var item in idList)
                    {
                        var pay = await _residenceInvoiceRepository.GetByIdAsync(item);
                        pay.IsPaid = true;
                        await _residenceInvoiceRepository.UpdateAsync(pay);
                    }
                }
                if (paymentType == 2)
                {
                    var idList = obj.PaymentIds;
                    foreach (var item in idList)
                    {
                        var pay =await _residenceDuesRepository.GetByIdAsync(item);
                        pay.IsPaid = true;
                        await _residenceDuesRepository.UpdateAsync(pay);
                    }
                    
                }

            });
        }
    }
}

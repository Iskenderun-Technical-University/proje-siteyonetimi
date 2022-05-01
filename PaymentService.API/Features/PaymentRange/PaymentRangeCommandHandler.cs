using MassTransit;
using MediatR;
using PaymentService.API.Repositories;
using Shared.Models.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentService.API.Features.PaymentRange
{
    public class PaymentRangeCommandHandler : IRequestHandler<PaymentRangeCommand, bool>
    {

        private readonly ICardRepository _cardRepository;
        private readonly IBus _busService;

        public PaymentRangeCommandHandler(ICardRepository cardRepository, IBus busService)
        {
            _cardRepository = cardRepository;
            _busService = busService;
        }

        public async Task<bool> Handle(PaymentRangeCommand request, CancellationToken cancellationToken)
        {
            var checkCard = await _cardRepository.GetCardByCardNumber(request.CardNumber);
            if (checkCard == null) return false;
            if (request.LastName != checkCard.LastName && request.FirstName != checkCard.LastName) return false;
            if (request.Fee >= checkCard.Balance) return false;

            var payment = new PaymentRangeShareModel();
            if (payment != null)
            {
                payment.Fee = request.Fee;
                payment.PaymentType = request.PaymentType;
                payment.PaymentIds = request.PaymentIds;
                Uri uri = new Uri("rabbitmq://localhost/paymentRangeQueue");
                var endPoint = await _busService.GetSendEndpoint(uri);
                await endPoint.Send(payment);

            }

            return true;
        }
    }
}

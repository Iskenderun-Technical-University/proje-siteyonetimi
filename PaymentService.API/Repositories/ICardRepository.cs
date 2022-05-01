using PaymentService.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentService.API.Repositories
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetAllCards();
        Task<Card> GetCardById(int id);
        Task<Card> GetCardByCardNumber(int cardNumber);
        Task<Card> AddCard(Card card);
        Task<bool> UpdateCard(Card card);
        Task<bool> DeleteCard(int id);

    }
}

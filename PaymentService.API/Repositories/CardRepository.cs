using MongoDB.Driver;
using PaymentService.API.Data.Persistence;
using PaymentService.API.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentService.API.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ICardContext _cardContext;

        public CardRepository(ICardContext cardContext)
        {
            _cardContext = cardContext ?? throw new ArgumentNullException(nameof(cardContext)); ;
        }

        public async Task<Card> AddCard(Card card)
        {
            await _cardContext.Cards.InsertOneAsync(card);
            return card;
        }

        public async Task<bool> DeleteCard(int id)
        {
            FilterDefinition<Card> filter = Builders<Card>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _cardContext
                                                .Cards
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Card>> GetAllCards()
        {
            return await _cardContext.Cards.Find(p => true).ToListAsync();
        }

        public async Task<Card> GetCardByCardNumber(int cardNumber)
        {
            return await _cardContext.Cards.Find(p => p.CardNumber == cardNumber).FirstOrDefaultAsync();
        }

        public async Task<Card> GetCardById(int id)
        {
            return await _cardContext.Cards.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCard(Card card)
        {
            var updateResult = await _cardContext
                                       .Cards
                                       .ReplaceOneAsync(filter: g => g.Id == card.Id, replacement: card);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}

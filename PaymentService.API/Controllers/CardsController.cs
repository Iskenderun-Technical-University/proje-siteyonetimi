using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaymentService.API.Entities;
using PaymentService.API.Models;
using PaymentService.API.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PaymentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;

        public CardsController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Card>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Card>>> GetAllCard()
        {
            var cards = await _cardRepository.GetAllCards();
            return Ok(cards);
        }

        [HttpGet("{id}", Name = "GetCard")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Card), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Card>> GetCardById(int id)
        {
            var card = await _cardRepository.GetCardById(id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }


        [HttpGet]
        [Route("CardNumber")]
        [ProducesResponseType(typeof(IEnumerable<Card>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Card>>> GetCardByCardNumber(int cardNumber)
        {
            var cards = await _cardRepository.GetCardByCardNumber(cardNumber);
            return Ok(cards);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Card), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Card>> AddCard([FromBody] Card card)
        {
            await _cardRepository.AddCard(card);

            return Ok(card);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Card), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCard([FromBody] Card card)
        {
            return Ok(await _cardRepository.UpdateCard(card));
        }

        [HttpDelete("{id)}", Name = "DeleteCard")]
        [ProducesResponseType(typeof(Card), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCardById(int id)
        {
            return Ok(await _cardRepository.DeleteCard(id));
        }
    }
}

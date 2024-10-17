using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KhoThoExe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetAllSubscriptions()
        {
            var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync();
            return Ok(subscriptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionDto>> GetSubscriptionById(int id)
        {
            var subscription = await _subscriptionService.GetSubscriptionByIdAsync(id);
            if (subscription == null) return NotFound();
            return Ok(subscription);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubscription(SubscriptionDto subscriptionDto)
        {
            await _subscriptionService.CreateSubscriptionAsync(subscriptionDto);
            return CreatedAtAction(nameof(GetSubscriptionById), new { id = subscriptionDto.SubscriptionID }, subscriptionDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubscription(int id, SubscriptionDto subscriptionDto)
        {
            if (id != subscriptionDto.SubscriptionID) return BadRequest();
            await _subscriptionService.UpdateSubscriptionAsync(id, subscriptionDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubscription(int id)
        {
            await _subscriptionService.DeleteSubscriptionAsync(id);
            return NoContent();
        }
    }
}

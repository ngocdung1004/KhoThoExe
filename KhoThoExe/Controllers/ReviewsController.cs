using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KhoThoExe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReviewById(int id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null) return NotFound();
            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReview(ReviewDto reviewDto)
        {
            await _reviewService.CreateReviewAsync(reviewDto);
            return CreatedAtAction(nameof(GetReviewById), new { id = reviewDto.ReviewID }, reviewDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReview(int id, ReviewDto reviewDto)
        {
            if (id != reviewDto.ReviewID) return BadRequest();
            await _reviewService.UpdateReviewAsync(id, reviewDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(int id)
        {
            await _reviewService.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}

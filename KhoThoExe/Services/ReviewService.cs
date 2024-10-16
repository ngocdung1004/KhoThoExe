using KhoThoExe.Data;
using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using KhoThoExe.Models;
using Microsoft.EntityFrameworkCore;

namespace KhoThoExe.Services
{
    public class ReviewService : IReviewService
    {
        private readonly KhoThoContext _context;

        public ReviewService(KhoThoContext context)
        {
            _context = context;
        }

        public async Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto)
        {
            var review = new Review
            {
                WorkerID = reviewDto.WorkerID,
                CustomerID = reviewDto.CustomerID,
                Rating = reviewDto.Rating,
                Comments = reviewDto.Comments,
                CreatedAt = DateTime.UtcNow // Đặt thời gian tạo hiện tại
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            reviewDto.ReviewID = review.ReviewID; // Gán lại ID đã được tạo
            return reviewDto;
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null) return false;

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ReviewDto>> GetAllReviewsAsync()
        {
            return await _context.Reviews.Select(r => new ReviewDto
            {
                ReviewID = r.ReviewID,
                WorkerID = r.WorkerID,
                CustomerID = r.CustomerID,
                Rating = r.Rating,
                Comments = r.Comments,
                CreatedAt = r.CreatedAt
            }).ToListAsync();
        }

        public async Task<ReviewDto> GetReviewByIdAsync(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null) return null;

            return new ReviewDto
            {
                ReviewID = review.ReviewID,
                WorkerID = review.WorkerID,
                CustomerID = review.CustomerID,
                Rating = review.Rating,
                Comments = review.Comments,
                CreatedAt = review.CreatedAt
            };
        }

        public async Task<ReviewDto> UpdateReviewAsync(int reviewId, ReviewDto reviewDto)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null) return null;

            review.Rating = reviewDto.Rating;
            review.Comments = reviewDto.Comments;

            await _context.SaveChangesAsync();
            return reviewDto;
        }
    }
}

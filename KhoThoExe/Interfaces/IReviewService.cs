using KhoThoExe.DTOs;

namespace KhoThoExe.Interfaces
{
    public interface IReviewService
    {
        Task<List<ReviewDto>> GetAllReviewsAsync();
        Task<ReviewDto> GetReviewByIdAsync(int reviewId);
        Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto);
        Task<ReviewDto> UpdateReviewAsync(int reviewId, ReviewDto reviewDto);
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}

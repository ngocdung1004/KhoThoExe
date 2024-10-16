using KhoThoExe.DTOs;

namespace KhoThoExe.Interfaces
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionDto>> GetAllSubscriptionsAsync();
        Task<SubscriptionDto> GetSubscriptionByIdAsync(int subscriptionId);
        Task<SubscriptionDto> CreateSubscriptionAsync(SubscriptionDto subscriptionDto);
        Task<SubscriptionDto> UpdateSubscriptionAsync(int subscriptionId, SubscriptionDto subscriptionDto);
        Task<bool> DeleteSubscriptionAsync(int subscriptionId);
    }
}

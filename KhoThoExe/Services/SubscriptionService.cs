using KhoThoExe.Data;
using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using KhoThoExe.Models;
using Microsoft.EntityFrameworkCore;

namespace KhoThoExe.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly KhoThoContext _context;

        public SubscriptionService(KhoThoContext context)
        {
            _context = context;
        }
        public async Task<SubscriptionDto> CreateSubscriptionAsync(SubscriptionDto subscriptionDto)
        {
            var subscription = new Subscription
            {
                WorkerID = subscriptionDto.WorkerID,
                SubscriptionType = subscriptionDto.SubscriptionType,
                PaymentStatus = subscriptionDto.PaymentStatus,
                StartDate = subscriptionDto.StartDate,
                EndDate = subscriptionDto.EndDate,
                QRCode = subscriptionDto.QRCode
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
            subscriptionDto.SubscriptionID = subscription.SubscriptionID; // Get the generated SubscriptionID
            return subscriptionDto;
        }

        public async Task<bool> DeleteSubscriptionAsync(int subscriptionId)
        {
            var subscription = await _context.Subscriptions.FindAsync(subscriptionId);
            if (subscription == null) return false;

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SubscriptionDto>> GetAllSubscriptionsAsync()
        {
            return await _context.Subscriptions.Select(s => new SubscriptionDto
            {
                SubscriptionID = s.SubscriptionID,
                WorkerID = s.WorkerID,
                SubscriptionType = s.SubscriptionType,
                PaymentStatus = s.PaymentStatus,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                QRCode = s.QRCode
            }).ToListAsync();
        }

        public async Task<SubscriptionDto> GetSubscriptionByIdAsync(int subscriptionId)
        {
            var subscription = await _context.Subscriptions.FindAsync(subscriptionId);
            if (subscription == null) return null;

            return new SubscriptionDto
            {
                SubscriptionID = subscription.SubscriptionID,
                WorkerID = subscription.WorkerID,
                SubscriptionType = subscription.SubscriptionType,
                PaymentStatus = subscription.PaymentStatus,
                StartDate = subscription.StartDate,
                EndDate = subscription.EndDate,
                QRCode = subscription.QRCode
            };
        }

        public async Task<SubscriptionDto> UpdateSubscriptionAsync(int subscriptionId, SubscriptionDto subscriptionDto)
        {
            var subscription = await _context.Subscriptions.FindAsync(subscriptionId);
            if (subscription == null) return null;

            subscription.SubscriptionType = subscriptionDto.SubscriptionType;
            subscription.PaymentStatus = subscriptionDto.PaymentStatus;
            subscription.StartDate = subscriptionDto.StartDate;
            subscription.EndDate = subscriptionDto.EndDate;
            subscription.QRCode = subscriptionDto.QRCode;

            await _context.SaveChangesAsync();
            return subscriptionDto;
        }
    }
}

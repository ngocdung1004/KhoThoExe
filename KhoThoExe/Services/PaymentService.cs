using KhoThoExe.Data;
using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using KhoThoExe.Models;
using Microsoft.EntityFrameworkCore;

namespace KhoThoExe.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly KhoThoContext _context;

        public PaymentService(KhoThoContext context)
        {
            _context = context;
        }
        public async Task<PaymentDto> CreatePaymentAsync(PaymentDto paymentDto)
        {
            var payment = new Payment
            {
                WorkerID = paymentDto.WorkerID,
                Amount = paymentDto.Amount,
                PaymentMethod = paymentDto.PaymentMethod,
                PaymentStatus = paymentDto.PaymentStatus,
                PaidAt = DateTime.UtcNow // Ghi lại thời gian thanh toán
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            paymentDto.PaymentID = payment.PaymentID; // Get the generated PaymentID
            return paymentDto;
        }

        public async Task<bool> DeletePaymentAsync(int paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null) return false;

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PaymentDto>> GetAllPaymentsAsync()
        {
            return await _context.Payments.Select(p => new PaymentDto
            {
                PaymentID = p.PaymentID,
                WorkerID = p.WorkerID,
                Amount = p.Amount,
                PaymentMethod = p.PaymentMethod,
                PaymentStatus = p.PaymentStatus,
                PaidAt = p.PaidAt
            }).ToListAsync();
        }

        public async Task<PaymentDto> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null) return null;

            return new PaymentDto
            {
                PaymentID = payment.PaymentID,
                WorkerID = payment.WorkerID,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                PaymentStatus = payment.PaymentStatus,
                PaidAt = payment.PaidAt
            };
        }

        public async Task<PaymentDto> UpdatePaymentAsync(int paymentId, PaymentDto paymentDto)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment == null) return null;

            payment.WorkerID = paymentDto.WorkerID;
            payment.Amount = paymentDto.Amount;
            payment.PaymentMethod = paymentDto.PaymentMethod;
            payment.PaymentStatus = paymentDto.PaymentStatus;
            payment.PaidAt = paymentDto.PaidAt; // Cập nhật thời gian thanh toán nếu cần

            await _context.SaveChangesAsync();
            return paymentDto;
        }
    }
}

using KhoThoExe.DTOs;

namespace KhoThoExe.Interfaces
{
    public interface IPaymentService
    {
        Task<List<PaymentDto>> GetAllPaymentsAsync();
        Task<PaymentDto> GetPaymentByIdAsync(int paymentId);
        Task<PaymentDto> CreatePaymentAsync(PaymentDto paymentDto);
        Task<PaymentDto> UpdatePaymentAsync(int paymentId, PaymentDto paymentDto);
        Task<bool> DeletePaymentAsync(int paymentId);
    }
}

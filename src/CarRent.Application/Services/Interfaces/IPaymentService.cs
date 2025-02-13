using CarRent.Application.Dtos.Payments;

namespace CarRent.Application.Services.Interfaces;

public interface IPaymentService
{
    Task ProcessPaymentAsync(PaymentDto paymentDto);
}

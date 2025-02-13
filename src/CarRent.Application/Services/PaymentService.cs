using AutoMapper;
using CarRent.Application.Dtos.Payments;
using CarRent.Application.Services.Interfaces;
using CarRent.Domain.Abstractions.Repositories;
using CarRent.Domain.Entities;

namespace CarRent.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IRelationalRepository<Payment> _paymentRepository;
    private readonly IMapper _mapper;

    public PaymentService(IRelationalRepository<Payment> paymentRepository, IMapper mapper)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
    }

    public async Task ProcessPaymentAsync(PaymentDto paymentDto)
    {
        var payment = _mapper.Map<Payment>(paymentDto);

        await _paymentRepository.UpdateAsync(payment);
    }
}

using AutoMapper;
using CarRent.Application.Dtos.Payments;
using CarRent.Domain.Entities;

namespace CarRent.Application.Mappings;

public class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<PaymentDto, Payment>();
    }
}

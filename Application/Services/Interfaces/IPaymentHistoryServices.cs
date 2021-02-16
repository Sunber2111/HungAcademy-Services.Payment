using Application.PaymentHistories.DTO;
using Domain;

namespace Application.Services.Interfaces
{
    public interface IPaymentHistoryServices : IBaseServices<PaymentHistoryDto, PaymentHistory>
    {

    }
}
using System;
using Application.PaymentHistories.DTO;
using Application.Services.Interfaces;
using Domain;

namespace Application.Services.Implements
{
    public class PaymentHistoryServices : BaseServices<PaymentHistoryDto, PaymentHistory>, IPaymentHistoryServices
    {
        public PaymentHistoryServices(IServiceProvider services) : base(services)
        {

        }
    }
}
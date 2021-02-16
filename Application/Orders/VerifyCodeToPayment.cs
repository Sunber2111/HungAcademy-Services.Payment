using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Services.Interfaces;
using Application.Status;
using MediatR;

namespace Application.Orders
{
    public class VerifyCodeToPayment
    {
        public class Command : IRequest<StatusAction>
        {
            public string Code { get; set; }

            public Guid OrderId { get; set; }
        }

        public class Handler : IRequestHandler<Command, StatusAction>
        {
            private readonly IOrderServices services;

            public Handler(IOrderServices services)
            {
                this.services = services;
            }

            public async Task<StatusAction> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await this.services.VerifyOrderByCodeAsync(request.OrderId, request.Code);
                
                if (result)
                    return new VerifyPaymentSuccess();

                throw new RestException(HttpStatusCode.BadRequest, new { message = "Xác thực thất bại" });
            }
        }
    }
}
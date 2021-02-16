using Application.Orders.DTO;
using Application.Services.Interfaces;
using Application.Status;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders
{
    public class ListByUserId
    {
        public class Hander
        {
            public class Command : IRequest<StatusAction>
            {
                public Guid UserId { get; set; }
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
                    try
                    {
                        var data = await this.services.GetByUserId(request.UserId);

                        return new GetDataSuccess<OrderDto>(data);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
    }
}


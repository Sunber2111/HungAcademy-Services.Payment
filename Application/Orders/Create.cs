using System.Threading;
using System.Threading.Tasks;
using Application.Orders.DTO;
using Application.Services.Interfaces;
using Application.Status;
using MediatR;

namespace Application.Orders
{
    public class Create
    {
        public class Command : IRequest<StatusAction>
        {
            public OrderCourseCreate order { get; set; }
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
                var result = await this.services.CreateOrderCourseAsync(request.order);

                return new CreateSuccessWithData<OrderInsertSuccess>(result, "hóa đơn");
            }
        }
    }
}
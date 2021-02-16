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
    public class Delete
    {
        public class Command : IRequest<StatusAction>
        {
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
                try
                {
                    await this.services.DeleteAsync(request.OrderId);
                    return new DeleteSuccess("hóa đơn");
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(NotFoundException))
                    {
                        throw new RestException(HttpStatusCode.BadRequest, new { message = "Hóa đơn không tồn tại" });
                    }
                    throw new RestException(HttpStatusCode.BadRequest, new { message = "Xóa hóa đơn thất bại" });
                }
        
            }
        }
    }
}
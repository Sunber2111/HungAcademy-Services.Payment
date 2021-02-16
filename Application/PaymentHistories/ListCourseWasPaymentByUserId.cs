using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Status;
using MediatR;

namespace Application.PaymentHistories
{
    public class ListCourseWasPaymentByUserId
    {
        public class Command : IRequest<StatusAction>
        {
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, StatusAction>
        {
            private readonly IPaymentHistoryServices services;

            public Handler(IPaymentHistoryServices services)
            {
                this.services = services;
            }

            public async Task<StatusAction> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await this.services.GetAsync(x => x.UserId.Equals(request.UserId));
                var listId = new List<string>();
                foreach (var item in result)
                {
                    listId.Add(item.CourseId.ToString());
                }
                return new GetDataSuccess<string>(listId);
            }
        }
    }
}
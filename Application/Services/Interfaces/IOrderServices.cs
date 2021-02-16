using Application.Orders.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IOrderServices : IBaseServices<OrderDto, Order>
    {
        Task<List<OrderDto>> GetByUserId(Guid userId);

        Task<OrderInsertSuccess> CreateOrderCourseAsync(OrderCourseCreate orderCourseCreate);

        Task<bool> VerifyOrderByCodeAsync(Guid orderId ,string code);
    }
}

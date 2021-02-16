using System;
using System.Collections.Generic;
using Application.UserInfoPayment.Dto;

namespace Application.Orders.DTO
{
    public class OrderDto
    {
        public bool IsPayment { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DatePayment { get; set; }

        public bool PaymentOnline { get; set; }

        public UserInfomationPaymentDto UserInfomationPayment { get; set; }

        public ICollection<OrderDetailCourseDto> OrderDetails { get; set; }

        public OrderDto()
        {
            OrderDetails = new List<OrderDetailCourseDto>();
        }

    }
}

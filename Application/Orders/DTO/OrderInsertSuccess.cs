using Application.UserInfoPayment.Dto;
using System;
using System.Collections.Generic;

namespace Application.Orders.DTO
{
    public class OrderInsertSuccess
    {
        public UserInfomationPaymentDto UserInfomationPayment { get; set; }

        public DateTime DateCreate { get; set; }

        public bool PaymentOnline { get; set; }

        public bool IsPayment { get; set; }

        public bool IsSend { get; set; }

        public ICollection<OrderDetailCourseCreate> OrderDetails { get; set; }

    }
}

using Application.UserInfoPayment.Dto;
using System;
using System.Collections.Generic;

namespace Application.Orders.DTO
{
    public class OrderCourseCreate
    {
        /// <summary>
        /// User information for payment
        /// </summary>

        public Guid UserId { get; set; }

        public UserInfomationPaymentDto UserInfomationPayment { get; set; }

        /// <summary>
        /// Order information
        /// </summary>

        public bool PaymentOnline { get; set; }

        public bool IsSend { get; set; }

        public DateTime DateCreate { get; set; }

        /// <summary>
        /// Order Detail information
        /// </summary>

        public ICollection<OrderDetailCourseCreate> OrderDetails { get; set; }

    }

    public class OrderDetailCourseCreate
    {
        public Guid CourseId { get; set; }

        public string CourseName { get; set; }

        public string Image { get; set; }

        public double Price { get; set; }

    }
}

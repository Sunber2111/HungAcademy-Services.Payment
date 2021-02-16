using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DatePayment { get; set; }

        public Guid UserId { get; set; }

        public bool PaymentOnline { get; set; }

        public bool IsPayment { get; set; }

        public bool IsSend { get; set; }

        public string ActivateKey { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual UserInfomationPayment UserInfomationPayment { get; set; }

    }
}

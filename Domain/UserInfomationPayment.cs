﻿using System;

namespace Domain
{
    public class UserInfomationPayment
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Address { get; set; }

        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}

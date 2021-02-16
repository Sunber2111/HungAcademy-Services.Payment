using System;

namespace Domain
{
    public class PaymentHistory
    {
        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }
    }
}

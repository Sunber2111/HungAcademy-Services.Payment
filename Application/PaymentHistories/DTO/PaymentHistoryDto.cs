using System;

namespace Application.PaymentHistories.DTO
{
    public class PaymentHistoryDto
    {
        public Guid UserId { get; set; }

        public Guid CourseId { get; set; }
    }
}
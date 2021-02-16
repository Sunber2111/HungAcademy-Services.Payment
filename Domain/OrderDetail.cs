using System;

namespace Domain
{
    public class OrderDetail
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public Guid CourseId { get; set; }

        public double Price { get; set; }

        public virtual Order Order { get; set; }
    }
}

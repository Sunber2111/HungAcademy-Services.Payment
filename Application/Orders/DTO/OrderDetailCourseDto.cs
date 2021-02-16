using Application.Courses;
using System;

namespace Application.Orders.DTO
{
    public class OrderDetailCourseDto
    {
        public Guid Id { get; set; }

        public double Price { get; set; }

        public readonly CourseDto Course;

        public OrderDetailCourseDto(CourseDto Course)
        {
            this.Course = Course;
        }
    }
}

using Application.Courses;
using Application.Courses.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ICourseServices
    {
        Task<List<CourseDto>> GetCoursesByListId(GetByListIdRequest request);
    }
}

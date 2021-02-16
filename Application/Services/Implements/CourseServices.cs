using Application.Courses;
using Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Application.Courses.Requests;
using Application.Errors;
using System.Net;

namespace Application.Services.Implements
{
    public class CourseServices : ICourseServices
    {
        private readonly HttpClient httpClient;

        public CourseServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<CourseDto>> GetCoursesByListId(GetByListIdRequest request)
        {
            var contentString = new StringContent(JsonConvert.SerializeObject(request),Encoding.UTF8,"application/json");

            using var httpResponse = await httpClient.PostAsync("course", contentString);

           
            if (httpResponse.IsSuccessStatusCode)
            {
                var contentResponse = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CourseDto>>(contentResponse);
            }

            throw new RestException(HttpStatusCode.BadGateway, new { message = "Lỗi từ Courses Services" });
        }
    }
}

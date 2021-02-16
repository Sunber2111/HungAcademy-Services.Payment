using API.Middlewares;
using Application.Mapper;
using Application.Orders;
using Application.Services.Implements;
using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.CodeOrderGenerate;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using System;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseNpgsql(Configuration.GetConnectionString("PaymentDataBase"));
            });

            services.AddMediatR(typeof(ListByUserId.Hander).Assembly);

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<IOrderServices, OrderServices>();

            services.AddTransient<IPaymentHistoryServices, PaymentHistoryServices>();

            services.AddTransient<ICodeOrderGenerator, CodeOrderGenerator>();

            services.AddHttpClient<ICourseServices, CourseServices>(client =>
            {
                client.BaseAddress = new Uri(Configuration["CourseService"]);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Application.Courses.Requests;
using Application.Errors;
using Application.Orders.DTO;
using Application.Services.Interfaces;
using Application.UserInfoPayment.Dto;
using Domain;
using Infrastructure.CodeOrderGenerate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class OrderServices : BaseServices<OrderDto, Order>, IOrderServices
    {
        private readonly ICourseServices courseServices;

        private readonly ICodeOrderGenerator codeOrderGenerator;

        public OrderServices(IServiceProvider serviceProvider, ICourseServices courseServices, ICodeOrderGenerator codeOrderGenerator) : base(serviceProvider)
        {
            this.courseServices = courseServices;
            this.codeOrderGenerator = codeOrderGenerator;
        }

        public async Task<OrderInsertSuccess> CreateOrderCourseAsync(OrderCourseCreate orderCourseCreate)
        {
            using (var unitOfWorks = NewDbContext())
            {
                try
                {
                    unitOfWorks.BeginTransaction();

                    var orderRepo = unitOfWorks.Repository<Order>();

                    var userInfoRepo = unitOfWorks.Repository<UserInfomationPayment>();

                    var order = new Order
                    {
                        PaymentOnline = orderCourseCreate.PaymentOnline,
                        IsSend = orderCourseCreate.IsSend,
                        DateCreate = DateTime.Now,
                        UserId = orderCourseCreate.UserId
                    };

                    order.OrderDetails = _mapper.Map<ICollection<OrderDetailCourseCreate>, ICollection<OrderDetail>>(orderCourseCreate.OrderDetails);

                    var userInfomation = _mapper.Map<UserInfomationPaymentDto, UserInfomationPayment>(orderCourseCreate.UserInfomationPayment);

                    order.UserInfomationPayment = userInfomation;

                    var resultInsertOrder = orderRepo.Insert(order);

                    var checkInsertAddOrder = await unitOfWorks.SaveChangeAsync();

                    if (!checkInsertAddOrder)
                        throw new Exception("Thêm hóa đơn cho khóa học thất bại");

                    var codeOrderCourseGenerator = this.codeOrderGenerator.Generate(resultInsertOrder.Id, resultInsertOrder.UserInfomationPayment.Id);

                    var orderUpdateCode = _mapper.Map<Order>(resultInsertOrder);

                    orderUpdateCode.ActivateKey = codeOrderCourseGenerator;

                    orderRepo.Update(orderUpdateCode);

                    var checkUpdateKey = await unitOfWorks.SaveChangeAsync();

                    if(!checkUpdateKey)
                        throw new Exception("Thêm thông tin mã dùng thất bại");

                    unitOfWorks.CommitTransaction();

                    var orderResult = _mapper.Map<OrderInsertSuccess>(resultInsertOrder);

                    orderResult.UserInfomationPayment = orderCourseCreate.UserInfomationPayment;

                    orderResult.OrderDetails = orderCourseCreate.OrderDetails;

                    return orderResult;

                }
                catch (Exception ex)
                {
                    unitOfWorks.RollbackTransaction();

                    throw ex;
                }
            }
        }

        public async Task<List<OrderDto>> GetByUserId(Guid userId)
        {
            using (var unitOfWork = NewDbContext())
            {
                var repo = unitOfWork.Repository<Order>();

                var orderListByUserId = await repo.GetManyAsync(x => x.UserId.Equals(userId));

                var listCourseId = new List<Guid>();

                var listOrderDto = new List<OrderDto>();

                foreach (var order in orderListByUserId)
                {
                    var orderDto = _mapper.Map<OrderDto>(order);

                    listOrderDto.Add(orderDto);

                    foreach (var orderDetail in order.OrderDetails)
                    {
                        listCourseId.Add(orderDetail.CourseId);
                    }
                }

                var listCourse = await this.courseServices.GetCoursesByListId(new GetByListIdRequest(listCourseId));

                var index = 0;

                foreach (var order in orderListByUserId)
                {
                    foreach (var orderDetail in order.OrderDetails)
                    {
                        var od = new OrderDetailCourseDto(listCourse[index]) { Id = orderDetail.Id, Price = orderDetail.Price };

                        listOrderDto[index].OrderDetails.Add(od);

                        index++;
                    }
                }

                return listOrderDto;
            }
        }

        public async Task<bool> VerifyOrderByCodeAsync(Guid orderId, string code)
        {
            try
            {
                using (var unitOfWork= NewDbContext())
                {
                    var repo = unitOfWork.Repository<Order>();

                    var orderInfo = await repo.FindAsync(orderId);

                    if (orderInfo == null)
                        throw new NotFoundException(new { message = "Không tồn tại hóa đơn" });

                    if(orderInfo.ActivateKey == code)
                    {
                        orderInfo.IsPayment = true;

                        var orderUpdate = _mapper.Map<Order>(orderInfo);

                        repo.Update(orderUpdate);

                        return await unitOfWork.SaveChangeAsync();

                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

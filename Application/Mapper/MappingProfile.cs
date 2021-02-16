using Application.Orders.DTO;
using Application.UserInfoPayment.Dto;
using AutoMapper;
using Domain;
using Application.PaymentHistories.DTO;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>();

            CreateMap<OrderDto, Order>();

            CreateMap<UserInfomationPaymentDto, UserInfomationPayment>();

            CreateMap<UserInfomationPayment, UserInfomationPaymentDto>();

            CreateMap<OrderDetailCourseCreate, OrderDetail>();

            CreateMap<OrderDetail, OrderDetailCourseCreate>();

            CreateMap<Order, OrderInsertSuccess>();

            CreateMap<PaymentHistoryDto, PaymentHistory>();

            CreateMap<PaymentHistory, PaymentHistoryDto>();

        }
    }
}

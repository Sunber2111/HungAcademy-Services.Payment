using System;
using System.Threading.Tasks;
using Application.PaymentHistories;
using Application.Status;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PaymentController : BaseController
    {
        [HttpGet("user/{id}")]
        public async Task<StatusAction> GetCourseByUserId(Guid id) => await Mediator.Send(new ListCourseWasPaymentByUserId.Command { UserId = id });
    }
}
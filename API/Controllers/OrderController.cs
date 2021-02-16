using System.Threading.Tasks;
using Application.Orders;
using Application.Status;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderController : BaseController
    {
        [HttpPost]
        public async Task<StatusAction> CreateOrder(Create.Command command) => await Mediator.Send(command);

        [HttpPost("verify")]
        public async Task<StatusAction> VerifyOrder(VerifyCodeToPayment.Command command) => await Mediator.Send(command);
    }
}
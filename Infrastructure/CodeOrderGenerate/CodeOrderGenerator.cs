using System;

namespace Infrastructure.CodeOrderGenerate
{
    public class CodeOrderGenerator : ICodeOrderGenerator
    {

        public CodeOrderGenerator()
        {
        }

        public string Generate(Guid orderId, Guid userId)
        {
            var orderIdStr = orderId.ToString();

            var userIdStr = userId.ToString();

            var orderIdArr = orderIdStr.Split('-');

            var userIdArr = userIdStr.Split('-');

            return orderIdArr[1] + "-" + userIdArr[1] + "-" + orderIdArr[2] + "-" + userIdArr[2];
        }
  }
}

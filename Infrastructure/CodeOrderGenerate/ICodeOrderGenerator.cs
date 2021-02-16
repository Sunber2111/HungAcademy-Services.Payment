using System;

namespace Infrastructure.CodeOrderGenerate
{
    public interface ICodeOrderGenerator
    {
        string Generate(Guid orderId, Guid userId);
    }
}

using System;
using System.Threading.Tasks;

namespace ProjectBC.Domain
{
    public interface IDomainCommandHandler
    {
        Task HandleAsync(IDomainCommand command);
        bool CanHandle(Type commandType);
    }
}
using System;
using System.Threading.Tasks;

namespace ProjectBC.Domain
{
    public interface IDomainCommandHandler
    {
        Task Handle(IDomainCommand command);
        bool CanHandle(Type commandType);
    }
}
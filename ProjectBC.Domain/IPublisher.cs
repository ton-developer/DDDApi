using System.Threading.Tasks;

namespace ProjectBC.Domain
{
    public interface IPublisher
    {
        Task Publish(IDomainCommand domainCommand);
    }
}
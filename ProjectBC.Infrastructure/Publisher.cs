using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ProjectBC.Domain;

namespace ProjectBC.Infrastructure
{
    public class Publisher : IPublisher
    {
        private readonly IServiceProvider _serviceProvider;

        public Publisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public async Task Publish(IDomainCommand domainCommand)
        {
            await _serviceProvider.GetServices<IDomainCommandHandler>()
                .FirstOrDefault(x => x.CanHandle(domainCommand.GetType()))
                .HandleAsync(domainCommand);
        }
    }
}
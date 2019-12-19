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
            var commandHandlers = _serviceProvider.GetServices<IDomainCommandHandler>();
            var compatibleHandlers = commandHandlers.Where(x => x.CanHandle(domainCommand.GetType()));

            foreach (var domainCommandHandler in compatibleHandlers)
            {
                await domainCommandHandler.Handle(domainCommand);
            }
        }
    }
}
using Banking.Core.Messages;
using Banking.Core.Messages.Notifications;
using MediatR;
using System.Threading.Tasks;

namespace Banking.Core.Communication
{
    public class MediatorHandler: IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishCommand<T>(T command) where T : Command
        {
            await _mediator.Send(command);
        }

        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);            
        }
    }
}

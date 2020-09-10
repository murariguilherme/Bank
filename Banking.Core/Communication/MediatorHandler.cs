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
        public async Task PublishNotification<T>(T notification) where T : DomainNotification
        {
            await _mediator.Publish(notification);            
        }
    }
}

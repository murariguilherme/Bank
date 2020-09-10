using Banking.Clients.Domain;
using Banking.Core.Communication;
using Banking.Core.Messages;
using Banking.Core.Messages.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Banking.Clients.Application.Commands
{
    public class ClientCommandHandler: IRequestHandler<RequestBankAccountClientCommand, bool>,
                                       IRequestHandler<UpdateClientCommand, bool>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IClientRepository _repository;

        public ClientCommandHandler(IMediatorHandler mediatorHandler, IClientRepository repository)
        {
            _mediatorHandler = mediatorHandler;
            _repository = repository;
        }

        public async Task<bool> Handle(RequestBankAccountClientCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(5000);
            return (new Random().Next(2) == 0);
        }

        public async Task<bool> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            if (!CommandIsValid(request)) return false;

            var clientdb = await _repository.GetByIdWithAddress(request.AggregateId);
            var client = new Client(request.Name, request.Birthday, request.Passport,
                            new Address(request.AggregateId, request.StreetAddress, request.City, request.State, request.PostalCode));
            
            client.Id = request.AggregateId;

            if (clientdb == null)
                await _repository.Create(client);
            else
            {
                client.Address.Id = clientdb.Address.Id;
                await _repository.Update(client);
            }
                

            return true;
        }

        private bool CommandIsValid(Command message)
        {
            if (message.IsValid()) return true;
            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublishNotification(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
            return false;
        }
    }
}

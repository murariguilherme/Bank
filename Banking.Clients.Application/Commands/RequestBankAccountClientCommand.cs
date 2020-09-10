using Banking.Core.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Clients.Application.Commands
{
    public class RequestBankAccountClientCommand : Command
    {
        public Guid ClientId { get; set; }

        public RequestBankAccountClientCommand(Guid clientId)
        {
            this.AggregateId = clientId;
            this.ClientId = clientId;
        }
        public override bool IsValid()
        {
            var validation = new RequestBankAccountClientCommandValidation().Validate(this);
            return validation.IsValid;
        }
    }

    public class RequestBankAccountClientCommandValidation : AbstractValidator<RequestBankAccountClientCommand>
    {
        public RequestBankAccountClientCommandValidation()
        {
            RuleFor(c => c.ClientId)
                .NotEmpty().WithMessage("Client must be valid.");
        }
    }
}

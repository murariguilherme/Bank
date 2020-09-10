using Banking.Clients.Application.Interfaces;
using Banking.Core.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Clients.Application.Commands
{
    public class UpdateAddressClientCommand : Command
    {
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }

        public UpdateAddressClientCommand(string streetaddress, string city, string state, string postalcode, IUser user)
        {
            this.StreetAddress = streetaddress;
            this.City = city;
            this.State = state;
            this.PostalCode = postalcode;
            this.AggregateId = user.GetUserId();
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateAddressClienteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateAddressClienteCommandValidation : AbstractValidator<UpdateAddressClientCommand>
    {
        public UpdateAddressClienteCommandValidation()
        {
            RuleFor(a => a.StreetAddress)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(a => a.City)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(a => a.State)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(a => a.PostalCode)
                .NotEmpty()
                .MaximumLength(15);
        }
    }
}

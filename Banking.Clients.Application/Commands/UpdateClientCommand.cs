using Banking.Clients.Application.Interfaces;
using Banking.Core.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Clients.Application.Commands
{
    public class UpdateClientCommand : Command
    {
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Passport { get; private set; }
        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }

        public UpdateClientCommand(string name, DateTime birthday, string passport, 
                                   string streetaddress, string city, string state, string postalcode,
                                   IUser user)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Passport = passport;
            this.StreetAddress = streetaddress;
            this.City = city;
            this.State = state;
            this.PostalCode = postalcode;
            this.AggregateId = user.GetUserId();
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateClientCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class UpdateClientCommandValidator: AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(c => c.Birthday)
                .NotEmpty();

            RuleFor(c => c.Passport)
                .NotEmpty()
                .MaximumLength(15);              

            RuleFor(c => c.StreetAddress)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(c => c.City)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(c => c.State)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(c => c.PostalCode)
                .NotEmpty()
                .MaximumLength(15);
        }
    }
}

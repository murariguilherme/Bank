using Banking.Core.DomainObjects;
using FluentValidation;
using Banking.Clients.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Clients.Domain
{
    public class Client : Entity
    {
        public string Name { get; private set; }
        public DateTime Birthday { get; private set; }
        public string Passport { get; private set; }

        public Client(string name, DateTime birthday, string passport)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Passport = passport;

            var validator = new ClientValidator();
            var result = validator.Validate(this);
            
            foreach (var error in result.Errors)
            {
                throw new DomainException(error.ErrorMessage);
            }
        }
    }

    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Invalid name.");

            RuleFor(c => c.Birthday)
                .NotEmpty()
                .WithMessage("Invalid birthday.");

            RuleFor(c => c.Passport)
                .NotEmpty()
                .WithMessage("Invalid passport.");
        }
    }
}

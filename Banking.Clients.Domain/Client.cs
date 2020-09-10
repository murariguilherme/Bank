using Banking.Core.DomainObjects;
using FluentValidation;
using System;
namespace Banking.Clients.Domain
{
    public class Client : Entity, IAggregationRoot
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

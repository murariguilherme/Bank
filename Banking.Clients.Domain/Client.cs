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
        public Address Address { get; set; }

        public Client(string name, DateTime birthday, string passport, Address address)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Passport = passport;
            this.Address = address;
        }

        public Client() { }
    }
}

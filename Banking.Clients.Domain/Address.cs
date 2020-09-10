using Banking.Core.DomainObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Clients.Domain
{
    public class Address: Entity
    {
        public string StreetAddress { get; private set; }        
        public string City { get; private set; }
        public string State { get; private set; }
        public string PostalCode { get; private set; }
        public Guid ClientId { get; private set; }
        public Client Client { get; set; }

        public Address(Guid clientid, string streetaddress, string city, string state, string postalcode)
        {
            this.ClientId = clientid;
            this.StreetAddress = streetaddress;
            this.City = city;
            this.State = state;
            this.PostalCode = postalcode;
        }
        public Address() { }
    }    
}

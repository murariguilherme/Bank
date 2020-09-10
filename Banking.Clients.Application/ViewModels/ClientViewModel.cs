using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Clients.Application.ViewModels
{
    public class ClientViewModel
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Passport { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}

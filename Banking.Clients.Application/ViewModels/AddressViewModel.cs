using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Clients.Application.ViewModels
{
    public class AddressViewModel
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
    }
}

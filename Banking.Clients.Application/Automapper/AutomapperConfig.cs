using AutoMapper;
using Banking.Clients.Application.ViewModels;
using Banking.Clients.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Clients.Application.Automapper
{
    public class AutomapperConfig: Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ClientViewModel, Client>()
                .ConstructUsing(c => new Client(c.Name, c.Birthday, c.Passport, 
                                               new Address(Guid.Empty, c.StreetAddress, c.City, c.State, c.PostalCode)
            ));

            CreateMap<Client, ClientViewModel>()
                .ForMember(a => a.StreetAddress, o => o.MapFrom(s => s.Address.StreetAddress))
                .ForMember(a => a.City, o => o.MapFrom(s => s.Address.City))
                .ForMember(a => a.State, o => o.MapFrom(s => s.Address.State))
                .ForMember(a => a.PostalCode, o => o.MapFrom(s => s.Address.PostalCode));
        }
    }
}

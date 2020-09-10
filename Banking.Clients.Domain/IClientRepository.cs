using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Clients.Domain
{
    public interface IClientRepository: IRepository<Client>
    {
        Task<Client> GetByIdWithAddress(Guid id);
    }
}

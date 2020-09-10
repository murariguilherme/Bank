using Banking.Clients.Domain;
using Banking.Clients.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Clients.Infra.Repository
{
    public class ClientRepository: Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext applicationDbContext): base(applicationDbContext)
        {            
        }
        public async Task<Client> GetByIdWithAddress(Guid id)
        {
            return await dbSet.AsNoTracking().Include(c => c.Address).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}

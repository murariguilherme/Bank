using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Clients.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}

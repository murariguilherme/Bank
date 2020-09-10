using Banking.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Core.DomainObjects
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

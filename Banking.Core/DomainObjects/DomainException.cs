using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Core.DomainObjects
{
    public class DomainException: Exception
    {
        public DomainException() {}

        public DomainException(string message): base(message) { }
    }
}

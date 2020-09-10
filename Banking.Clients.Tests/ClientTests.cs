using System;
using Xunit;
using Banking.Clients.Domain;
using Banking.Core.DomainObjects;

namespace Banking.Clients.Tests
{
    public class ClientTests
    {
        [Fact]
        public void Clients_Validaton_MustReturnException()
        {
            var ex = Assert.Throws<DomainException>(() =>
                new Client("", new DateTime(1996, 04, 18), "CA99999AA")
            );
            Assert.Equal("Invalid name.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Client("Ben Afleck", new DateTime(0), "CA99999AA")
            );
            Assert.Equal("Invalid birthday.", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Client("Ben Afleck", new DateTime(1996, 04, 18), "")
            );
            Assert.Equal("Invalid passport.", ex.Message);
        }

        [Fact]
        public void Clients_Validaton_MustNotReturnExceptionAsync()
        {
            var ex = Record.Exception(() =>
                new Client("Ben Afleck", new DateTime(1996, 04, 18), "CA99999AA")
            );            
            Assert.Null(ex);
        }
    }
}

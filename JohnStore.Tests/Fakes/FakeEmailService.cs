using System;
using System.Collections.Generic;
using System.Text;
using JohnStore.Domain.StoreContext.Services;

namespace JohnStore.Tests.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body) { }
    }
}

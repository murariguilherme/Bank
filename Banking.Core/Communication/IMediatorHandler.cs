using Banking.Core.Messages;
using Banking.Core.Messages.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Communication
{
    public interface IMediatorHandler
    {
        Task PublishNotification<T>(T notification) where T : DomainNotification;
        Task PublishCommand<T>(T command) where T : Command;
    }
}

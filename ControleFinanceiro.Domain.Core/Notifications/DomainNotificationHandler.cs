using ControleFinanceiro.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        private List<DomainNotification> _notifications;
        public List<DomainNotification> GetNotications()
        {
            return _notifications;
        }

        public Task Handler(DomainNotification message)
        {
            _notifications.Add(message);

            return Task.CompletedTask;
        }

        public bool HasNotifications()
        {
            return _notifications?.Any() == true;
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}

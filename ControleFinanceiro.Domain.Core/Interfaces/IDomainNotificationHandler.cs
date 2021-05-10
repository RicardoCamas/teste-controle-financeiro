using ControleFinanceiro.Domain.Core.Events;
using ControleFinanceiro.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Interfaces
{
    public interface IDomainNotificationHandler<T>:IHandler<T> where T:Message
    {
        bool HasNotifications();
        List<T> GetNotications();
    }
}

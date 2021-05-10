using ControleFinanceiro.Domain.Core.Bus;
using ControleFinanceiro.Domain.Core.Commands;
using ControleFinanceiro.Domain.Core.Events;
using ControleFinanceiro.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Infra.CrossCutting.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor();
        public Task PublicarEvento<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
            return Task.CompletedTask;
        }

        public Task PublicarCommando<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
            return Task.CompletedTask;
        }

        private static void Publish<T>(T message) where T: Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification")
                ? typeof(IDomainNotificationHandler<T>)
                : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handler(message);
        }
    }
}

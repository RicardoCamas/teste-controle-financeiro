using ControleFinanceiro.Domain.Core.Commands;
using ControleFinanceiro.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task PublicarCommando<T>(T theCommand) where T : Command;
        Task PublicarEvento<T>(T theEvent) where T : Event;
    }
}

using ControleFinanceiro.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Core.Interfaces
{
    public interface IHandler<in T> where T: Message
    {
        Task Handler(T request);
    }
}

using ControleFinanceiro.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Commands
{
    public abstract class Command:Message
    {
        public Command()
        {
            Timestamp = DateTime.Now;
        }
        public DateTime Timestamp { get; private set; }
    }
}

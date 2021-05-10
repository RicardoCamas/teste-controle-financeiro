using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Events
{
    public abstract class Event:Message
    {
        public Event()
        {
            Timestamp = DateTime.Now;
        }
        public DateTime Timestamp { get; private set; }
    }
}

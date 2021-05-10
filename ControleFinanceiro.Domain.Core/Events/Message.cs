using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Events
{
    public abstract class Message
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }
    }
}

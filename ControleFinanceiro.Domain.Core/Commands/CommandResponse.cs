using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Commands
{
    public class CommandResponse
    {
        public CommandResponse(bool sucesso = false)
        {
            Success = sucesso;
        }

        public static CommandResponse Ok = new CommandResponse() { Success = true };
        public static CommandResponse Fail = new CommandResponse() { Success = true };

        public bool Success { get; private set; }
    }
}

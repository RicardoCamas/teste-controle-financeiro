using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Utils
{
    public class ValidationError
    {
        public ValidationError(string message) { }
        public string Message { get; set; }
    }
}

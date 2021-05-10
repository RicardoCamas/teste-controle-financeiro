using ControleFinanceiro.Domain.Core.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ControleFinanceiro.Domain.Core.Notifications
{
    public class ValidationResult
    {
        public ValidationResult() { }

        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsValid { get; }
        public string ObjectJsonReturn { get; set; }
        public IEnumerable<ValidationError> Erros { get; }
        public void AdicionarErro(ValidationError error) { }
        public void AdicionarErro(params ValidationResult[] resultadoValidacao){}
    }
}

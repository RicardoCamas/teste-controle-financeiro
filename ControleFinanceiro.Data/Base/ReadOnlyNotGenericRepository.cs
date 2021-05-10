using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Data.Base
{
    public class ReadOnlyNotGenericRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected ReadOnlyNotGenericRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}

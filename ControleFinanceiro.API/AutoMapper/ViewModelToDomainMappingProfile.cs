using AutoMapper;
using ControleFinanceiro.Domain.Commands.Lancamentos;
using ControleFinanceiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.API.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
<<<<<<< HEAD
             CreateMap<LancamentoBaseCommand, Lancamento>();
=======
            CreateMap<LancamentoBaseCommand, Lancamento>();
>>>>>>> ae866c0fa2e23405e78bb19070e6c587c1abbc36
        }
    }
}

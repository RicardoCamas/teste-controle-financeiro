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
            CreateMap<LancamentoBaseCommand, Lancamento>();
        }
    }
}

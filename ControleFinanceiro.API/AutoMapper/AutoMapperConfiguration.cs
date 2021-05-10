﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.API.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration registerMappings()
        {
            return new MapperConfiguration(ps=> {
                ps.AddProfile(new DomainToViewModelMappingProfile());
                ps.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
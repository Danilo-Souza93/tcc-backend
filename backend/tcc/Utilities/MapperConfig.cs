﻿using AutoMapper;
using tcc.EntityModels;
using tcc.Models;
using tcc.Strategies;

namespace tcc.Utilities
{
    public class MapperConfig : MapperConfigurationExpression
    {
        public MapperConfig() 
        { 
            CreateMap<ProdutoModel, ProdutoEntityModel>().ReverseMap();
            CreateMap<VendaModel, VendaEntityModel>().ReverseMap();
            
        }
    }
}

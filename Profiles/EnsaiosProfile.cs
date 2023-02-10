using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnsaioBack.DataTransfer;
using EnsaioBack.Entidades;

namespace EnsaioBack.Profiles
{
    public class EnsaiosProfile : Profile
    {
        public EnsaiosProfile() => CreateMap<EnsaioInserirRequest, Ensaio>();
    }
}
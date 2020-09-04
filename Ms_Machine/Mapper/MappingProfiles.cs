using AutoMapper;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Models;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ms_Machine.Domain.Poulina.MSmachine.Domain;
using Microsoft.OpenApi.Extensions;

namespace Ms_Machine.Domain.Poulina.MSmachine.Domain.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Machine, MachineDTO>()
         .ForMember(a => a.label_fournisseur, i => i.MapFrom(src => src.Fournisseur.label))
         .ReverseMap();

            CreateMap<Service, serviceDTO>()
         .ForMember(a => a.label_filiaire, i => i.MapFrom(src => src.Filiaire.label))
         .ReverseMap();



        }
    }
}

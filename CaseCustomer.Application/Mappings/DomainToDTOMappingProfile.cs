using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CaseCustomer.Application.DTOs;
using CaseCustomer.Domain.Entities;


namespace CaseCustomer.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Documento, DocumentoDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }

    }
}

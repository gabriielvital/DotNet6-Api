using AutoMapper;
using GB.ApiDotNet6.Application.DTOs;
using GB.ApiDotNet6.Domain.Entities;
using System;

namespace GB.ApiDotNet6.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
        }
    }
}

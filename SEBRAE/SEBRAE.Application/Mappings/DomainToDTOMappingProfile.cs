using AutoMapper;
using SEBRAE.Application.DTOs;
using SEBRAE.Domain.Entities;

namespace SEBRAE.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Conta, ContaDTO>().ReverseMap();
        }
    }
}

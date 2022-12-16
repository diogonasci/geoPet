using AutoMapper;
using GeoPet.Application.DTOs;
using GeoPet.Domain.Entities;

namespace GeoPet.Application.Mappings;

    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<PetOwner, PetOwnerDTO>().ReverseMap();
            CreateMap<Pet, PetDTO>().ReverseMap();
        }
    }
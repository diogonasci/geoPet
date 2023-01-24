using AutoMapper;
using GeoPet.Application.DTOs;
using GeoPet.Application.Interfaces;
using GeoPet.Domain.Entities;
using GeoPet.Domain.Interfaces;

namespace GeoPet.Application.Services;

    public class PetOwnerService : IPetOwnerService
    {
        private IPetOwnerRepository _petOwnerRepository;
        private readonly IMapper _mapper;
        public PetOwnerService(IPetOwnerRepository petOwnerRepository,
            IMapper mapper)
        {
            _petOwnerRepository = petOwnerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PetOwnerDTO>> GetPetOwners()
        {
            var categoriesEntity = await _petOwnerRepository.GetPetOwnersAsync();
            return _mapper.Map<IEnumerable<PetOwnerDTO>>(categoriesEntity);
        }

        public async Task<PetOwnerDTO> GetById(int? id)
        {
            var petOwnerEntity = await _petOwnerRepository.GetByIdAsync(id);
            return _mapper.Map<PetOwnerDTO>(petOwnerEntity);
        }

        public async Task<PetOwnerDTO> Add(PetOwnerDTO petOwnerDto)
        {
            var petOwnerEntity = _mapper.Map<PetOwner>(petOwnerDto);

            var entity = await _petOwnerRepository.CreateAsync(petOwnerEntity);

            return _mapper.Map<PetOwnerDTO>(entity);

        }

        public async Task Update(PetOwnerDTO petOwnerDto)
        {
            var petOwnerEntity = _mapper.Map<PetOwner>(petOwnerDto);
            await _petOwnerRepository.UpdateAsync(petOwnerEntity);
        }

        public async Task Remove(int? id)
        {
            var petOwnerEntity = _petOwnerRepository.GetByIdAsync(id).Result;
            await _petOwnerRepository.RemoveAsync(petOwnerEntity);
        }
    }

using AutoMapper;
using GeoPet.Application.DTOs;
using GeoPet.Application.Interfaces;
using GeoPet.Domain.Entities;
using GeoPet.Domain.Interfaces;

namespace Catalogo.Application.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;

        private readonly IMapper _mapper;
        public PetService(IMapper mapper, IPetRepository petRepository)
        {
            _petRepository = petRepository ??
                 throw new ArgumentNullException(nameof(petRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<PetDTO>> GetPets()
        {
            var petsEntity = await _petRepository.GetPetsAsync();
            return _mapper.Map<IEnumerable<PetDTO>>(petsEntity);
        }

        public async Task<PetDTO> GetById(int? id)
        {
            var petEntity = await _petRepository.GetByIdAsync(id);
            return _mapper.Map<PetDTO>(petEntity);
        }

        public async Task Add(PetDTO petDto)
        {
            var petEntity = _mapper.Map<Pet>(petDto);
            await _petRepository.CreateAsync(petEntity);
        }

        public async Task Update(PetDTO petDto)
        {

            var petEntity = _mapper.Map<Pet>(petDto);
            await _petRepository.UpdateAsync(petEntity);
        }

        public async Task Remove(int? id)
        {
            var petEntity = _petRepository.GetByIdAsync(id).Result;
            await _petRepository.RemoveAsync(petEntity);
        }
    }
}

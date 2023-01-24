using GeoPet.Application.DTOs;

namespace GeoPet.Application.Interfaces;
    public interface IPetOwnerService
    {
        Task<IEnumerable<PetOwnerDTO>> GetPetOwners();
        Task<PetOwnerDTO> GetById(int? id);
        Task<PetOwnerDTO> Add(PetOwnerDTO petOwnerDto);
        Task Update(PetOwnerDTO petOwnerDto);
        Task Remove(int? id);
    }

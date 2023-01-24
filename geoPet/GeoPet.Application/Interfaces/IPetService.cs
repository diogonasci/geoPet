using GeoPet.Application.DTOs;

namespace GeoPet.Application.Interfaces;

public interface IPetService
{
    Task<IEnumerable<PetDTO>> GetPets();
    Task<PetDTO> GetById(int? id);
    Task<PetDTO> Add(PetDTO petDto);
    Task Update(PetDTO petDto);
    Task Remove(int? id);
}

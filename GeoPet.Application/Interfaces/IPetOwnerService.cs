using GeoPet.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeoPet.Application.Interfaces
{
    public interface IPetOwnerService
    {
        Task<IEnumerable<PetOwnerDTO>> GetPetOwners();
        Task<PetOwnerDTO> GetById(int? id);
        Task Add(PetOwnerDTO petOwnerDto);
        Task Update(PetOwnerDTO petOwnerDto);
        Task Remove(int? id);
    }
}

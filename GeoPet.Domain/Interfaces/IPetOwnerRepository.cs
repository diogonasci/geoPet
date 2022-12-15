using GeoPet.Domain.Entities;

namespace GeoPet.Domain.Interfaces
{
    public interface IPetOwnerRepository
    {
        Task<IEnumerable<PetOwner>> GetPetOwnersAsync();
        Task<PetOwner> GetByIdAsync(int? id);
        Task<PetOwner> CreateAsync(PetOwner petOwner);
        Task<PetOwner> UpdateAsync(PetOwner petOwner);
        Task<PetOwner> RemoveAsync(PetOwner petOwner);
    }
}

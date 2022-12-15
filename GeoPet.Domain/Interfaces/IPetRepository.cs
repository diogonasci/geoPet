using GeoPet.Domain.Entities;

namespace GeoPet.Domain.Interfaces
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetPetsAsync();
        Task<Pet> GetByIdAsync(int? id);
        Task<Pet> CreateAsync(Pet pet);
        Task<Pet> UpdateAsync(Pet pet);
        Task<Pet> RemoveAsync(Pet pet);
    }
}

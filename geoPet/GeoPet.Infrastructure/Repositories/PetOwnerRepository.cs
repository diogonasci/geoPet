using GeoPet.Domain.Entities;
using GeoPet.Domain.Interfaces;
using GeoPet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GeoPet.Infrastructure.Repositories;

public class PetOwnerRepository : IPetOwnerRepository
{
    private ApplicationDbContext _petOwnerContext;
    public PetOwnerRepository(ApplicationDbContext context)
    {
        _petOwnerContext = context;
    }

    public async Task<PetOwner> CreateAsync(PetOwner petOwner)
    {
        _petOwnerContext.Add(petOwner);
        await _petOwnerContext.SaveChangesAsync();
        return petOwner;
    }

    public async Task<PetOwner> GetByIdAsync(int? id)
    {
        return await _petOwnerContext.PetOwners.FindAsync(id);
    }

    public async Task<IEnumerable<PetOwner>> GetPetOwnersAsync()
    {
        return await _petOwnerContext.PetOwners.ToListAsync();
    }

    public async Task<PetOwner> RemoveAsync(PetOwner petOwner)
    {
        _petOwnerContext.Remove(petOwner);
        await _petOwnerContext.SaveChangesAsync();
        return petOwner;
    }

    public async Task<PetOwner> UpdateAsync(PetOwner petOwner)
    {
        _petOwnerContext.Update(petOwner);
        await _petOwnerContext.SaveChangesAsync();
        return petOwner;
    }
}

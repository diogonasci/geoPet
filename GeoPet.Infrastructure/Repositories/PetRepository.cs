using GeoPet.Domain.Entities;
using GeoPet.Domain.Interfaces;
using GeoPet.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GeoPet.Infrastructure.Repositories;

public class PetRepository : IPetRepository
{
    private ApplicationDbContext _petContext;
    public PetRepository(ApplicationDbContext context)
    {
        _petContext = context;
    }

    public async Task<Pet> CreateAsync(Pet pet)
    {
        _petContext.Add(pet);
        await _petContext.SaveChangesAsync();
        return pet;
    }

    public async Task<Pet> GetByIdAsync(int? id)
    {
        //return await _petContext.Pets.FindAsync(id);
        return await _petContext.Pets.Include(c => c.PetOwner)
           .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Pet>> GetPetsAsync()
    {
        return await _petContext.Pets.ToListAsync();
    }

    public async Task<Pet> RemoveAsync(Pet pet)
    {
        _petContext.Remove(pet);
        await _petContext.SaveChangesAsync();
        return pet;
    }

    public async Task<Pet> UpdateAsync(Pet pet)
    {
        _petContext.Update(pet);
        await _petContext.SaveChangesAsync();
        return pet;
    }
}

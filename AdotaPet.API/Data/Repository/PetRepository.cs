using AdotaPet.API.Data.Context;
using AdotaPet.API.Domain.Entity;
using AdotaPet.API.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace AdotaPet.API.Data.Repository
{
    public class PetRepository : IPetRepository
    {
        private DataBaseContext _context;
        public PetRepository(DataBaseContext context)
        {
            _context = context;
        }
        public Pet Add(Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        public bool Delete(Guid id)
        {
            var obj = this.GetById(id);
            if (obj == null)
            {
                return false;
            }

            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<Pet>> GetAll()
        {
            return await _context.Pets.Include(p => p.Owner).ToListAsync();
        }

        public Pet GetById(Guid id)
        {
            return _context.Pets.Where(a => a.Id == id).FirstOrDefault();
        }

        public Pet Update(Guid id, Pet pet)
        {
            var obj = GetById(id);
            if (obj == null)
            {
                return null;
            }
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return obj;
        }
    }
}

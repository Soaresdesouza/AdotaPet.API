using AdotaPet.API.Domain.Entity;

namespace AdotaPet.API.Domain.Interface
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetAll();
        Pet GetById(Guid id);
        Pet Add(Pet pet);
        Pet Update(Guid id, Pet pet);
        bool Delete(Guid id);
    }
}

using AdotaPet.API.Domain.Entity;

namespace AdotaPet.API.Domain.Interface
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        Client GetById(Guid id);
        Client Add(Client person);
        Client Update(Guid id, Client person);
        bool Delete(Guid id);
    }
}

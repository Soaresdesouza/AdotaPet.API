using AdotaPet.API.Data.Context;
using AdotaPet.API.Domain.Entity;
using AdotaPet.API.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdotaPet.API.Data.Repository
{
    public class ClientRepository : IClientRepository
    {
        private DataBaseContext _context;
        public ClientRepository(DataBaseContext context)
        {
            _context = context;
        }
        public Client Add(Client person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }
        public Client Update(Guid id, Client person)
        {
            var obj = GetById(id);
            if (obj == null)
            {
                return null;
            }

            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();
            return obj;
        }
        public bool Delete(Guid id)
        {
            var obj = GetById(id);
            if (obj == null)
            {
                return false;
            }

            _context.Remove(obj);
            _context.SaveChanges();
            return true;
        }

        public List<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public Client GetById(Guid id)
        {
            return _context.Clients.Where(c => c.Id == id).FirstOrDefault();
        }


    }
}

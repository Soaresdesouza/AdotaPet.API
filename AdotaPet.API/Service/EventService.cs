using AdotaPet.API.Data.Context;
using AdotaPet.API.Domain.Entity;

namespace AdotaPet.API.Service
{
    public class EventService : IEventService
    {
        private DataBaseContext _context;
        public EventService(DataBaseContext context)
        {
            _context = context;
        }
        public void GenerateFakeData()
        {
            var owner = new Client()
            {
                CPF = "111.111.111-22",
                Name = "Andrew",
                Email = "andrew@email.com"
            };
            _context.Add(owner);
            var pet = new Pet()
            {
                Name = "Wise",
                Type = Util.PetType.Dog,
                Owner = owner,
            };
            _context.Add(pet);
            _context.SaveChanges();
        }
    }
}

using AdotaPet.API.Util;

namespace AdotaPet.API.Domain.Entity
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public PetType Type { get; set; }
        public Client Owner { get; set; }
    }
}

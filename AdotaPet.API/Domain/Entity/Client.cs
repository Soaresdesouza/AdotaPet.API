using System.ComponentModel.DataAnnotations;

namespace AdotaPet.API.Domain.Entity
{
    public class Client
    {
        public Client()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        //public ICollection<Pet>? Pets { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace TP3._11.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public Passaporte? Passaporte { get; set; }
    }
}

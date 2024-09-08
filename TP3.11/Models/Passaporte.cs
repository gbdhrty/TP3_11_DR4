using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3._11.Models
{
    public class Passaporte
    {
        [Key]
        [ForeignKey("Pessoa")]
        public int Id { get; set; }
        public int Numero { get; set; }

        public Pessoa? Pessoa { get; set; }
    }
}

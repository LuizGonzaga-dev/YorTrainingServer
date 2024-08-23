using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace YorTrainingServer.Models
{
    public class Filial
    {
        public int FilialId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(12)]
        public string Telefone { get; set; }

        [Required]
        [StringLength(30)]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsDeleted { get; set; } = false;

        public int AcademiaId { get; set; }
        public virtual Academia Academia { get; set; }

        [Required]
        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace YorTrainingServer.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefone { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoFuncionario { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public virtual ICollection<Filial> Filiais { get; set; }
    }
}

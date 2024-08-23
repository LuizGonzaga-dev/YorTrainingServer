using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using YorTrainingServer.ViewModels.Endereco;
using System.Text.Json.Serialization;

namespace YorTrainingServer.Models
{
    public class Endereco
    {
        public int EnderecoID { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoEndereco { get; set; } // Residencial, Comercial, etc.

        [Required]
        [StringLength(255)]
        public string Logradouro { get; set; } // Nome da rua, avenida, etc.

        [Required]
        [StringLength(10)]
        public string Numero { get; set; } // Número da casa/apartamento

        [StringLength(100)]
        public string Complemento { get; set; } // Apartamento, bloco, etc.

        [StringLength(100)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(100)]
        public string Estado { get; set; }

        [Required]
        [StringLength(20)]
        public string CEP { get; set; } // Código postal

        [Required]
        [StringLength(100)]
        public string Pais { get; set; } = "Brasil";

        [JsonIgnore]
        public virtual Filial Filial { get; set; }
        [JsonIgnore]
        public virtual Funcionario Funcionario { get; set; }

        public Endereco() {}

        public Endereco(CreateEndereco data)
        {
            Bairro = data.Bairro;
            CEP = data.CEP;
            Cidade = data.Cidade;
            Complemento = data.Complemento;
            Estado = data.Estado;
            Logradouro = data.Logradouro;
            Numero = data.Numero;
            Pais = data.Pais;
            TipoEndereco = data.TipoEndereco;
        }

    }
}

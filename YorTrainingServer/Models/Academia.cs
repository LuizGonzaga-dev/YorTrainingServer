using System.ComponentModel.DataAnnotations;

namespace YorTrainingServer.Models
{
    public class Academia
    {
        public string AcademiaId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Filial> Filiais { get; set; }
    }
}

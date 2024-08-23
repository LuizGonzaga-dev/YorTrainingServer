using System.ComponentModel.DataAnnotations;

namespace YorTrainingServer.Models
{
    public class Academia
    {
        public int AcademiaId { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Filial> Filiais { get; set; }
    }
}

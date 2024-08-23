using YorTrainingServer.ViewModels.Endereco;

namespace YorTrainingServer.ViewModels.Filial
{
    public class CreateFilial
    {
        public int FilialId { get; set; }
        public string Name { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string AcademiaId { get; set; }
        public CreateEndereco Endereco { get; set; }
    }
}

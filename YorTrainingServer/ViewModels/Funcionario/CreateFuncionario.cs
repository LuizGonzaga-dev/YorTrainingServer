using YorTrainingServer.ViewModels.Endereco;

namespace YorTrainingServer.ViewModels.Funcionario
{
    public class CreateFuncionario
    {
        public int FuncionarioId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get;set; }
        public int FilialId { get; set; }
        public string TipoFuncionario { get; set; }
        public CreateEndereco Endereco { get; set; }
    }
}

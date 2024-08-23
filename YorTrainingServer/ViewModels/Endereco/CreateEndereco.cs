﻿namespace YorTrainingServer.ViewModels.Endereco
{
    public class CreateEndereco
    {
        public int EnderecoId { get; set; }
        public string TipoEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Pais { get; set; }
    }
}

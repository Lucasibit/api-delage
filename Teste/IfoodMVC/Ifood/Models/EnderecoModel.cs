using System.ComponentModel.DataAnnotations;

namespace Ifood.Models
{
    public class EnderecoModel
    {
        [Key()]
        public int Id { get; set; }
        public string Bairro { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Rua { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public int Numero { get; set; } = 0;
    }
}
using Ifood.Models;

namespace Ifood.Services
{
    public interface IEnderecoService
    {
        Task<EnderecoModel> SalvarEndereco(EnderecoModel endereco);

    }
}

using Ifood.Data;
using Ifood.Models;

namespace Ifood.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IfoodContext context;
        public EnderecoService(IfoodContext context)
        {
            this.context = context;
        }

        public async Task<EnderecoModel> SalvarEndereco(EnderecoModel endereco)
        {
            if (endereco != null)
            {
                await context.Enderecos.AddAsync(endereco);
                await context.SaveChangesAsync();
                return endereco;

            }
            throw new Exception("Endereco nulo");
        }
    }
}

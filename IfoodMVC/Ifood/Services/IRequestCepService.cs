namespace Ifood.Services
{
    public interface IRequestCepService
    {
        public Task<Object> BuscarCep(string cep);
    }
}

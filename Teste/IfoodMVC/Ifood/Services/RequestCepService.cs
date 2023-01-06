using Ifood.Models;

namespace Ifood.Services
{
    public class RequestCepService : IRequestCepService
    {

        public async Task<Object> BuscarCep(string cep)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                var data = await response.Content.ReadAsStringAsync();

                var objectData = Newtonsoft.Json.JsonConvert.DeserializeObject<RequestCepModel>(data);
                return objectData;

            }
            catch (Exception ex)
            {
                return null;
            } 

        }

    }
}

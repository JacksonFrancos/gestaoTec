using System.Net.Http.Json;
using commo.Commons.Results;
using WebUi.Services.Interface;

namespace WebUi.Services.Impl
{
    public class ClientService : IClientService
    {

        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<Result> CreateClientAsync(ClientDTO model, CancellationToken token = default)
        {
               var response = await _httpClient.PostAsJsonAsync("api/clients", model, token);
            if (response.IsSuccessStatusCode)
            
                return Result.Ok();

            return Result.Fail(
                new Error(
                    "Erro ao criar cliente",
                    response.StatusCode.ToString(),
                    "Não foi possível criar o cliente. Verifique os dados e tente novamente."
                )
            );
        }
    }


    public record ClientDTO(
        string Name,
        string Address,
        string Email,
        int Number,
        Guid ClientId
    );
}

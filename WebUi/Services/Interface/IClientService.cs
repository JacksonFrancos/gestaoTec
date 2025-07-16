using commo.Commons.Results;
using WebUi.Services.Impl;

namespace WebUi.Services.Interface
{
    public interface IClientService
    {

        Task<Result> CreateClientAsync(ClientDTO model, CancellationToken token = default);

    }
}

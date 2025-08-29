using commo.Commons.Results;
using commo.DTOs;
using WebUi.Services.Impl;

namespace WebUi.Services.Interface
{
    public interface IClientService
    {

        Task<Result> CreateClientAsync(ClientDTO model, CancellationToken token = default);

    }
}

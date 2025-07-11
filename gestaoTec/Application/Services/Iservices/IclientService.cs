using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestaoTec.Application.Commons.Results;
using gestaoTec.Domain.Entities;

namespace gestaoTec.Application.Services.Iservices
{
    public interface IClientService
    {

       Task<Result> SaveAsync(Client client);

       Task<Result> DeleteAsync(Client client);

       Task<Result> ListAsync (CancellationToken token = default);
    }
}

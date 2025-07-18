using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using commo.Commons.Results;
using gestaoTec.Application.Models;
using gestaoTec.Domain.Entities;

namespace gestaoTec.Application.Services.Iservices
{
    public interface IClientService
    {

        Task<Result> SaveAsync(SaveClient model, CancellationToken token = default);

        Task<Result> DeleteAsync(Client client);

       Task<Result> ListAsync (CancellationToken token = default);
    }
}

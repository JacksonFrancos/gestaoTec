using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestaoTec.Application.Commons.Results;
using gestaoTec.Application.Services.Iservices;
using gestaoTec.Domain.Entities;
using gestaoTec.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gestaoTec.Application.Services.Impls
{
    public class ClientService : IClientService
    {
        private GestTecContext Database { get; }

        public ClientService(GestTecContext database)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
        }
        public async Task<Result> SaveAsync(Client client)
        {
            var existingClient = await Database.Clients.FirstOrDefaultAsync(x => x.ClientId == client.ClientId);
            if (existingClient is null)
            {
                await Database.Clients.AddAsync(client);
            }
            else
            {
                client.Update(existingClient.Name, existingClient.Email, existingClient.Address);
                Database.Clients.Update(client);
            }

            var result = await Database.SaveChangesAsync();

            return Result.Ok();
        }

        public async Task<Result> DeleteAsync(Client client)
        {
            var existingClient = await Database.Clients.FirstOrDefaultAsync(x => x.ClientId == client.ClientId);
            if (existingClient is null)
            {
                throw new ArgumentException("Cliente não encontrado", nameof(client));
            }
            else
            {
                Database.Clients.Remove(existingClient);
            }

            return Result.Ok();
        }


        public async Task<Result> ListAsync(CancellationToken token = default)
        {
            var clients = await Database.Clients.ToListAsync(token);
            return Result.Ok();

        }




    }
}

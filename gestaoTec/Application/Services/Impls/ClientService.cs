using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestaoTec.Application.Commons.Results;
using gestaoTec.Application.Models;
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
        public async Task<Result> SaveAsync(SaveClient model, CancellationToken token = default)
        {
            var existingClient = await Database.Clients.FirstOrDefaultAsync(x => x.ClientId == model.ClientId);
            if (existingClient is null)
            {
                var client = Client.Create(
                    model.Name,
                    model.Email,
                    model.Address,
                    model.ClientId
                );
                client.Number = model.Number;
               
            }
            else
            {
                existingClient.Update(
                    model.Name,
                    model.Email,
                    model.Address
                );
                Database.Clients.Update(existingClient);

            }

            var result = await Database.SaveChangesAsync(token);

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

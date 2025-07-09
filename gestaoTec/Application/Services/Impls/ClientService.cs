using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestaoTec.Domain.Entities;
using gestaoTec.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace gestaoTec.Application.Services.Impls
{
    public class ClientService
    {
        private GestTecContext Database { get; }

        public ClientService(GestTecContext database)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
        }
        public async Task<> SaveAsync(Client client)
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

        }

        public async Task<> DeleteAsync(Client client)
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
        }


        public async Task<> listAsync(CancellationToken token = default)
        {
            return await Database.Clients.ToListAsync(token);
        }




    }
}

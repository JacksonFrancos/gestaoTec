using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestaoTec.Infrastructure.Data;

namespace gestaoTec.Application.Services.Impls
{
    public class ClientService
    {
        private GestTecContext Database { get; }

        public ClientService(GestTecContext database)
        {
            Database = database ?? throw new ArgumentNullException(nameof(database));
        }

        


    }
}

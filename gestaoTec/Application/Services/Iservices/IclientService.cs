using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestaoTec.Application.Services.Iservices
{
    public class IclientService
    {

       Task<> SaveAsync(Client client);

       Task<> DeleteAsync(Client client);

       Task<> ListAsync (CancellationToken token = default);
    }
}

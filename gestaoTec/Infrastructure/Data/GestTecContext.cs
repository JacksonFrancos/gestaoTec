using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestaoTec.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace gestaoTec.Infrastructure.Data
{
    // classe criada para poder fazer a conexção com o banco de dados
    public class GestTecContext(DbContextOptions<GestTecContext>options) : DbContext (options)
    {
     public DbSet<Client> Clients  { get; set; }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<ServiceOrder> ServiceOrders { get; set; }
    }
}

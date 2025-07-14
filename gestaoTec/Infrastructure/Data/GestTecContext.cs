using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // 🔹 Equipment → Client (M:1)
            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.Client)
                .WithMany(c => c.Equipments)
                .HasForeignKey("ClientId") // assumindo que a FK exista no banco
                .OnDelete(DeleteBehavior.NoAction); // Evita o cascade aqui

            // 🔹 ServiceOrder → Equipment (M:1)
            modelBuilder.Entity<ServiceOrder>()
                .HasOne(so => so.Equipment)
                .WithMany(e => e.ServiceOrders)
                .HasForeignKey("EquipmentId")
                .OnDelete(DeleteBehavior.NoAction); // Evita outro cascade

            // 🔹 ServiceOrder → Client (M:1)
            modelBuilder.Entity<ServiceOrder>()
                .HasOne(so => so.Client)
                .WithMany(c => c.ServiceOrders)
                .HasForeignKey("ClientId")
                .OnDelete(DeleteBehavior.NoAction); // também evita o ciclo
        }
    }
}

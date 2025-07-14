using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestaoTec.Application.Models;
using gestaoTec.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gestaoTec.Application.Mappings
{
    public  class ClientMapping : IEntityTypeConfiguration<Client>
    {

        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.ToTable("Clients")
                .HasKey(x => x.ClientId);

            builder
                .Property(x => x.Name)
                .IsRequired();
            builder
                .Property(x => x.Address)
                .IsRequired();
            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(x => x.Number)
                .IsRequired()
                .HasDefaultValue(0);

        }
    }
}

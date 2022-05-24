using HistoricoMedico.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Infrastructure.Persistence.Configurations
{
    internal class DependenteConfigurations : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
           builder
                .HasKey(d => d.Id);

            builder
              .HasOne(u => u.Usuario)
              .WithMany(d => d.Dependentes)
              .HasForeignKey(c => c.IdUsuario)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

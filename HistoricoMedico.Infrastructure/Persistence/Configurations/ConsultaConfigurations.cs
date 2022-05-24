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
    public class ConsultaConfigurations : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Consultas)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Medico)
                .WithMany(m => m.Consultas)
                .HasForeignKey(c => c.IdMedico)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


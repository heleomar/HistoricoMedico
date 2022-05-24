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
    public class MedicoConfigurations : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
               .HasOne(m => m.Usuario)
               .WithMany(u => u.Medicos)
               .HasForeignKey(m => m.IdUsuario)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

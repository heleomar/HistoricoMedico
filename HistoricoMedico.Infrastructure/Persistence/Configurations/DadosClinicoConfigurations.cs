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
    internal class DadosClinicoConfigurations : IEntityTypeConfiguration<DadosClinico>
    {
        public void Configure(EntityTypeBuilder<DadosClinico> builder)
        {
            builder
                 .HasOne(u => u.Usuario)
                 .WithOne(d => d.DadosClinico)
                 .HasForeignKey<DadosClinico>(u => u.IdUsuario);            
            
        }
    }
}

using HistoricoMedico.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HistoricoMedico.Infrastructure.Persistence
{
    public class HistoricoMedicoDbContext : DbContext
    {
        public HistoricoMedicoDbContext(DbContextOptions<HistoricoMedicoDbContext> options) : base(options)
        {
           
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }        

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tabelas
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                      
        }

    }
}
